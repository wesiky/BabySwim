using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat
{
    public enum CommonTips
    {
        [Description("执行成功")]
        SUCCESS=0,
        [Description("家长不存在或编号与名称不一致")]
        FAMILY_UNEXIST=101
    }
}
