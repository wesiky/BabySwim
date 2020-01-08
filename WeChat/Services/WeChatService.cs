using System;
using System.Collections.Generic;
using System.Linq;
using WeChat.IReponsitory;
using WeChat.IServices;
using WeChat.Models;
using WeChat.Models.Result;

namespace WeChat.Services
{
    public class WeChatService : IWeChatService
    {
        public IFamilyReponsitory FamilyReponsitory { get; set; }
        public ISelectionStudentReponsitory SelectionStudentReponsitory { get; set; }

        public ISelectionReponsitory SelectionReponsitory { get; set; }
        public BaseFamily GetFamily(string familyCode, string familyName)
        {
            BaseFamily family = FamilyReponsitory.GetSingleWhere(a => a.FamilyCode == familyCode && a.FamilyName == familyName);
            return family;
        }

        public bool Bind(BaseFamily model)
        {
            FamilyReponsitory.BatchUpdate(a => a.OpenId == model.OpenId, a => new BaseFamily { OpenId = null });
            return FamilyReponsitory.Edit(model);
        }

        /// <summary>
        /// 获取未签到和当前日期之后的选课记录(非试听课)
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public List<CourseSelectionStudent> GetSelectionStudent(string openId)
        {
            IQueryable<CourseSelectionStudent> selectionStudents = SelectionStudentReponsitory.GetSelectionStudentDetail(
                a=> a.StudentInfo.Family.OpenId == openId 
                && a.Selection.CourseDate >= DateTime.Now.Date
                && a.SignType == 0
                && a.Selection.CourseID != 29);
            return selectionStudents.ToList();
        }

        public BaseResult CancelSelectionStudent(int selectionStudentId,string openId)
        {
            BaseResult result = new BaseResult();
            CourseSelectionStudent selectionStudent = SelectionStudentReponsitory.GetSelectionStudent(selectionStudentId);
            if (selectionStudent == null)
            {
                //选课记录不存在
                result.ResultCode = (int)CommonTips.UNKNOW_SELECTIONSTUDENT;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return result;
            }
            if(selectionStudent.StudentInfo == null)
            {
                //学员信息不存在
                result.ResultCode = (int)CommonTips.UNKNOW_STUDENTINFO;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return result;
            }
            if(selectionStudent.StudentInfo.Family == null)
            {
                //家长信息不存在
                result.ResultCode = (int)CommonTips.UNKNOW_FAMILY;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return result;
            }
            if(selectionStudent.Selection == null)
            {
                //排课记录不存在
                result.ResultCode = (int)CommonTips.UNKNOW_SELECTION;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return result;
            }
            //openid不一致，说明为异常请求，不执行删除
            if (string.IsNullOrEmpty(selectionStudent.StudentInfo.Family.OpenId) || (!(selectionStudent.StudentInfo.Family.OpenId.Equals(openId))))
            {
                result.ResultCode = (int)CommonTips.UNKNOW_OPTION;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return result;
            }
            //课程已签到不允许取消
            if(selectionStudent.SignType != 0)
            {
                result.ResultCode = (int)CommonTips.FAILED_SIGNED;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return result;
            }
            //试听课不允许取消
            if(selectionStudent.Selection?.CourseID == 29)
            {
                result.ResultCode = (int)CommonTips.FAILED_IS_TRYOUT;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return result;
            }
            //删除选课
            if (SelectionStudentReponsitory.Delete(selectionStudent))
            {
                //当选课人数少于等于1位时，取消课程
                if (selectionStudent.Selection.SelectionStudents.Count == 0)
                {
                    SelectionReponsitory.Delete(selectionStudent.Selection);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取指定日期学员清单
        /// </summary>
        /// <returns></returns>
        public List<CourseSelectionStudent> GetSelectionStudentByDate(DateTime dateTime)
        {
            IQueryable<CourseSelectionStudent> selectionStudents = SelectionStudentReponsitory.GetSelectionStudentDetail(a=>a.Selection.CourseDate == dateTime.Date);
            return selectionStudents.ToList();
        }

        /// <summary>
        /// 获取指定日期学员清单
        /// </summary>
        /// <returns></returns>
        public CourseSelectionStudent GetSelectionStudent(int selectionStudentId)
        {
            CourseSelectionStudent selectionStudent = SelectionStudentReponsitory.GetSelectionStudent(selectionStudentId);
            return selectionStudent;
        }
    }
}
