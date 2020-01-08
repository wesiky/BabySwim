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
        FAMILY_UNEXIST=101,
        [Description("家长账号未绑定微信")]
        FAMILY_UNBIND = 102,
        [Description("课程已签到,取消失败")]
        FAILED_SIGNED = 110,
        [Description("试听课不可取消")]
        FAILED_IS_TRYOUT = 111,
        [Description("学员信息不存在")]
        UNKNOW_STUDENTINFO = 901,
        [Description("家长信息不存在")]
        UNKNOW_FAMILY = 902,
        [Description("选课记录不存在")]
        UNKNOW_SELECTIONSTUDENT = 903,
        [Description("排课记录不存在")]
        UNKNOW_SELECTION = 904,
        [Description("异常操作")]
        UNKNOW_OPTION = 999
    }
}
