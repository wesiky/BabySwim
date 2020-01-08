using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Context;
using WeChat.IReponsitory;
using WeChat.Models;

namespace WeChat.Reponsitory
{
    public class StudentInfoReponsitory : BaseReponsitory<BaseStudentInfo>, IStudentInfoReponsitory
    {
        public StudentInfoReponsitory(WeChatContext content) : base(content)
        {
        }
    }
}
