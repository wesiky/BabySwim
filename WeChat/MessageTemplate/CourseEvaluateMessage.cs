using Senparc.Weixin.Entities.TemplateMessage;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.MessageTemplate
{
    public class CourseEvaluateMessage : TemplateMessageBase
    {
        public TemplateDataItem first { get; set; }
        public TemplateDataItem keyword1 { get; set; }
        public TemplateDataItem keyword2 { get; set; }
        public TemplateDataItem keyword3 { get; set; }
        public TemplateDataItem remark { get; set; }

        public TemplateDataItem url { get; set; }

        /// <summary>
        /// “课程评价”模板消息数据定义 构造函数
        /// </summary>
        /// <param name="_first"></param>
        /// <param name="_userName"></param>
        /// <param name="_courseName"></param>
        /// <param name="_teacherName"></param>
        /// <param name="_remark"></param>
        /// <param name="templateId"></param>
        /// <param name="url"></param>
        public CourseEvaluateMessage(string _first,
            string _userName,
            string _courseName,
            string _teacherName,
            string _remark,
            string _url,
            string templateId = "mcyjLQzOTJiluwPhCxsGowxeNbPZ7E6C8dx5hp2FwnA")
            : base(templateId, _url, "课程评价")
        {
            /* 模板格式
                {{first.DATA}}
                学员姓名：{{keyword1.DATA}}
                课程名称：{{keyword2.DATA}}
                主讲老师：{{keyword3.DATA}}
                {{remark.DATA}}
                */

            first = new TemplateDataItem(_first);
            keyword1 = new TemplateDataItem(_userName);
            keyword2 = new TemplateDataItem(_courseName);
            keyword3 = new TemplateDataItem(_teacherName);
            remark = new TemplateDataItem(_remark);
            url = new TemplateDataItem(_url);
        }
    }
}
