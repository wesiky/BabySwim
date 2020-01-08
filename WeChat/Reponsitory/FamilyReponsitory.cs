using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Context;
using WeChat.IReponsitory;
using WeChat.Models;

namespace WeChat.Reponsitory
{
    public class FamilyReponsitory : BaseReponsitory<BaseFamily>, IFamilyReponsitory
    {
        public FamilyReponsitory(WeChatContext content) : base(content)
        {
        }

        public BaseFamily GetFamily(string openId)
        {
            return Context.Families
                .Include(a => a.StudentInfos).ThenInclude(a => a.Student)
                .Include(a => a.StudentInfos).ThenInclude(a => a.Course)
                .Include(a => a.StudentInfos).ThenInclude(a => a.Teacher)
                .Include(a => a.StudentInfos).ThenInclude(a => a.Adviser)
                .FirstOrDefault(a=>a.OpenId == openId);
        }
    }
}
