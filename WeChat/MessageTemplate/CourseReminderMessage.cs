using Senparc.Weixin.Entities.TemplateMessage;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.MessageTemplate
{
    public class CourseReminderMessage : TemplateMessageBase
    {
        public TemplateDataItem first { get; set; }
        public TemplateDataItem keyword1 { get; set; }
        public TemplateDataItem keyword2 { get; set; }
        public TemplateDataItem remark { get; set; }

        public TemplateDataItem url { get; set; }

        /// <summary>
        /// “课程提醒”模板消息数据定义 构造函数
        /// </summary>
        /// <param name="_first">first.Data头部信息</param>
        /// <param name="userName">用户名</param>
        /// <param name="orderNumber">订单号</param>
        /// <param name="orderAmount">订单金额</param>
        /// <param name="productInfo">商品信息</param>
        /// <param name="_remark">remark.Data备注</param>
        /// <param name="url"></param>
        /// <param name="templateId"></param>
        public CourseReminderMessage(string _first, string _courseName,
            string _userName,
            string _remark,
            string templateId = "Njb6PJu047ZGjXiYdy-Gj4ICFkHWBPDfXur9Y0Ll2Ec",
            string url = null)
            : base(templateId, url, "课程提醒")
        {
            /* 模板格式
                {{first.DATA}}
                课程：{{keyword1.DATA}}
                参加人：{{keyword2.DATA}}
                {{remark.DATA}}
                */

            first = new TemplateDataItem(_first);
            keyword1 = new TemplateDataItem(_courseName);
            keyword2 = new TemplateDataItem(_userName);
            remark = new TemplateDataItem(_remark);
        }
    }
}
