using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XF.Common;
using Enums;
using XF.ExControls;
using System.Collections;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace BabySwim
{
    public partial class FrmCourseEvaluateSelection : Form
    {
        XF.BLL.Course_Selection bll = new XF.BLL.Course_Selection();
        XF.BLL.Course_SelectionStudent bllStudent = new XF.BLL.Course_SelectionStudent();
        XF.BLL.XF_Configuration bllConfiguration = new XF.BLL.XF_Configuration();
        XF.BLL.SysManage bllSys = new XF.BLL.SysManage();
        DateTime dt = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
        private XF.ExControls.XFClassScheduler xfClassScheduler1;
        int StoreID = -1;//门店ID
        int ClassRoomID = -1; //教室ID
        public FrmCourseEvaluateSelection()
        {
            InitializeComponent();
        }

        private void FrmCourseEvaluateSelection_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            BindData();
        }

        private void xfClassScheduler1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //判断是否可选
            if (!zDataConverter.ToString(xfClassScheduler1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag).Equals(string.Empty))
            {
                XF.Model.Course_Selection model;
                int selectionID = zDataConverter.ToInt(xfClassScheduler1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag);
                model = bll.GetDetailModel(selectionID);
                FrmCourseEvaluate frmCourseEvaluate = new FrmCourseEvaluate();
                frmCourseEvaluate.Model = model;
                frmCourseEvaluate.ShowDialog();
                if (frmCourseEvaluate.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //更新评价
                    ArrayList lstSql = new ArrayList();
                    foreach (XF.Model.Course_SelectionStudent student in model.SelectionStudents)
                    {
                        lstSql.Add(bllStudent.GetUpdateEvaluateSql(student));

                    }
                    if (bllSys.ExecuteSqlTran(lstSql))
                    {
                        string resultMsg = string.Empty;
                        foreach (XF.Model.Course_SelectionStudent student in model.SelectionStudents)
                        {
                            BaseResult result = SendEvaluate(student.OpenId,student.SelectionStudentID);
                            if (result.ResultCode != 0)
                            {
                                resultMsg += "学员" + student.StudentName + "评价推送失败：" + result.ResultMsg;
                            }
                        }
                        if(resultMsg.Equals(string.Empty))
                        {
                            QQMessageBox.Show(this, MessageText.TIP_SUCCESS_SAVE, MessageText.MESSAGEBOX_CAPTION_TIP, QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
                        }
                        else
                        {
                            QQMessageBox.Show(this, resultMsg, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        QQMessageBox.Show(this, MessageText.SQL_ERROR_SELECTIONSTUDENT_EVALUATE_SAVE, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                        return;
                    }
                }
            }
        }

        private void BindData()
        {
            if(xfClassScheduler1 == null)
            {
                int roomCount = zDataConverter.ToInt(bllConfiguration.GetItemValueByCache("RoomCount"));
                int dayCount = zDataConverter.ToInt(bllConfiguration.GetItemValueByCache("DayCount"));
                string[] roomNames = zDataConverter.ToString(bllConfiguration.GetItemValueByCache("RoomNames")).Split(',');
                string[] dayNames = zDataConverter.ToString(bllConfiguration.GetItemValueByCache("DayNames")).Split(',');
                xfClassScheduler1 = new XFClassScheduler(dayCount, roomCount, roomNames, dayNames);
                xfClassScheduler1.Dock = DockStyle.Fill;
                xfClassScheduler1.CellClick += xfClassScheduler1_CellClick;
                this.Controls.Add(xfClassScheduler1);
            }
            DataTable dtSelection = bll.GetDayDetailList(dt, StoreID, ClassRoomID).Tables[0];
            //设置已选课数据
            foreach (DataRow dr in dtSelection.Rows)
            {
                XF.Model.Course_Selection model = bll.DataRowToModel(dr);
                xfClassScheduler1.Rows[model.LessonNO].Cells[model.ClassRoomID].Style.BackColor = ColorTranslator.FromHtml(model.Color);
                xfClassScheduler1.Rows[model.LessonNO].Cells[model.ClassRoomID].Value = string.Format("{0}第{1}节{2}选课人数：{3}{2}授课老师：{4}", model.CourseName, model.SectionNO, MessageText.KEY_ENTER, zDataConverter.ToString(model.SelectionCount), model.TeacherName);
                if (model.CourseID != zDataConverter.ToInt(ConfigSetting.TryOutCourseID))
                {
                    xfClassScheduler1.Rows[model.LessonNO].Cells[model.ClassRoomID].Tag = model.SelectionID;
                }
            }
        }

        private void XfClassScheduler1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 推送评价
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="selectionStudentId"></param>
        /// <returns></returns>
        private BaseResult SendEvaluate(string openId,int selectionStudentId)
        {
            try
            {
                string url = ConfigSetting.ApiUrl + "/SendEvaluate";
                string postDatas = "openId=" + openId + "&selectionStudentId=" + selectionStudentId;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Referer = "";
                request.Accept = "Accept:text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
                request.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";
                request.UserAgent = "User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
                request.KeepAlive = true;
                //上面的http头看情况而定，但是下面俩必须加 
                request.ContentType = "application/x-www-form-urlencoded";
                Encoding encoding = Encoding.UTF8;//根据网站的编码自定义
                request.Method = "post";  //--需要将get改为post才可行
                string postDataStr;
                if (postDatas != "")
                {
                    postDataStr = postDatas;//--需要封装,形式如“arg=arg1&arg2=arg2”
                    byte[] postData = encoding.GetBytes(postDataStr);//postDataStr即为发送的数据，
                    request.ContentLength = postData.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(postData, 0, postData.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();


                StreamReader streamReader = new StreamReader(responseStream, encoding);
                string retString = streamReader.ReadToEnd();
                BaseResult result = JsonConvert.DeserializeObject<BaseResult>(retString);//反序列化
                streamReader.Close();
                responseStream.Close();
                return result;
            }
            catch (Exception ex)
            {
                return new BaseResult(999, "推送异常,请联系管理员！异常信息：" + ex.Message);
            }
        }
    }
}
