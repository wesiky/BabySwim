using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XF.Common;
using System.Collections;
using XF.ExControls;
using Enums;

namespace BabySwim
{
    public partial class FrmCourseScheduler : Form
    {
        int storeID = -1;
        int classRoomID = -1;

        XF.BLL.Course_Scheduler bll = new XF.BLL.Course_Scheduler();
        XF.BLL.XF_Configuration bllConfiguration = new XF.BLL.XF_Configuration();
        XF.BLL.SysManage bllSys = new XF.BLL.SysManage();
        public FrmCourseScheduler()
        {
            InitializeComponent();
        }

        private void xfCourseScheduler1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (zDataConverter.ToString(xfCourseScheduler1.SelectedCells[0].Value).Equals(MessageText.HAS_SCHEDULER))
            {
                xfCourseScheduler1.SelectedCells[0].Value = string.Empty;
            }
            else
            {
                xfCourseScheduler1.SelectedCells[0].Value = MessageText.HAS_SCHEDULER;
            }
        }

        private void FrmCourseScheduler_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            int dayCount = zDataConverter.ToInt(bllConfiguration.GetItemValueByCache("DayCount"));
            List<string> rowDescription = new List<string>();
            string[] rowDescriptions = zDataConverter.ToString(bllConfiguration.GetItemValueByCache("RowDescription")).Split(',');
            if (rowDescriptions.Length > 0)
            {
                for (int i = 0; i < rowDescriptions.Length; i++)
                {
                    rowDescription.Add(rowDescriptions[i]);
                }
            }
            xfCourseScheduler1.DayCount = dayCount;
            xfCourseScheduler1.RowDescription = rowDescription;
            BindData();
        }

        private void BindData()
        {
            List<XF.Model.Course_Scheduler> models = bll.GetModelList(storeID, classRoomID);
            foreach (XF.Model.Course_Scheduler model in models)
            {
                //设置课表区间内的课程
                if (model.WeekDay < xfCourseScheduler1.Columns.Count && model.LessonNO < xfCourseScheduler1.DayCount)
                {
                    xfCourseScheduler1.Rows[model.LessonNO].Cells[model.WeekDay].Value = MessageText.HAS_SCHEDULER;
                }
            }
        }
        /// <summary>
        /// 保存数据采用先清除，后增加策略
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            ArrayList lstSql = new ArrayList();
            XF.Model.Course_Scheduler model = new XF.Model.Course_Scheduler();
            lstSql.Add(bll.GetDeleteSql(storeID,classRoomID));
            model.StoreID = storeID;
            model.ClassRoomID = classRoomID;
            foreach (DataGridViewRow dgvr in xfCourseScheduler1.Rows)
            {
                foreach (DataGridViewCell dgvc in dgvr.Cells)
                {
                    if (zDataConverter.ToString(dgvc.Value).Equals(MessageText.HAS_SCHEDULER))
                    {
                        model.WeekDay = dgvc.ColumnIndex;
                        model.LessonNO = dgvc.RowIndex;
                        lstSql.Add(bll.GetAddSql(model));
                    }
                }
            }
            if (bllSys.ExecuteSqlTran(lstSql))
            {
                QQMessageBox.Show(
                    this,
                    MessageText.TIP_SUCCESS_SAVE,
                    MessageText.MESSAGEBOX_CAPTION_TIP,
                    QQMessageBoxIcon.OK,
                    QQMessageBoxButtons.OK);
            }
            else
            {
                QQMessageBox.Show(
                    this,
                    MessageText.SQL_ERROR_SCHEDULER_SAVE,
                    MessageText.MESSAGEBOX_CAPTION_ERROR,
                    QQMessageBoxIcon.Error,
                    QQMessageBoxButtons.OK);
            }
        }
    }
}
