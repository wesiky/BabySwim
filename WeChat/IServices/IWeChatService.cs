using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Models;
using WeChat.Models.Result;

namespace WeChat.IServices
{
    public interface IWeChatService
    {
        BaseFamily GetFamily(string familyCode, string familyName);

        bool Bind(BaseFamily model);

        List<CourseSelectionStudent> GetSelectionStudent(string openId);

        BaseResult CancelSelectionStudent(int selectionStudentId, string openId);

        List<CourseSelectionStudent> GetSelectionStudentByDate(DateTime dateTime);

        CourseSelectionStudent GetSelectionStudent(int selectionStudentId);
    }
}
