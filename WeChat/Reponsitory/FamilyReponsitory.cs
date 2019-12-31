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
    }
}
