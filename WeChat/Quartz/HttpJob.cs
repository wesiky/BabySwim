using Quartz;
using Senparc.Weixin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeChat.Models;
using WeChat.Context;
using WeChat.MessageTemplate;
using Senparc.Weixin.MP.AdvancedAPIs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WeChat.IServices;
using System.Runtime.CompilerServices;
using WeChat.IReponsitory;

namespace WeChat.Quartz
{
    public class HttpJob : IJob
    {

        //public ISelectionStudentReponsitory SelectionStudentReponsitory { get; set; }

        //public IWeChatService _weChatService;

        //public HttpJob(IWeChatService weChatService)
        //{
        //    _weChatService = weChatService;
        //}

        //WeChatContext db;
        //public HttpJob(WeChatContext content)
        //{
        //    this.db = content;
        //}

        //public HttpJob()
        //{

        //}

        /// <summary>
        /// 通过group和name判断是要执行哪个任务  具体（任务执行逻辑）业务逻辑写后面
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                var name = context.JobDetail.Key.Name;
                var group = context.JobDetail.Key.Group;

                //发送微信提醒
                if (group == "WeChat" && name == "SendCourseReminder")
                {
                    using (var dbContext = ServiceCollectionExtension.New<WeChatContext>())
                    {
                        List<CourseSelectionStudent> selectionStudents = dbContext.SelectionStudents
                            .Include(a => a.Selection).ThenInclude(a => a.SelectionStudents)
                            .Include(a => a.StudentInfo).ThenInclude(a => a.Family)
                            .Include(a => a.Selection).ThenInclude(a => a.Course)
                            .Include(a => a.StudentInfo).ThenInclude(a=>a.Student)
                            .Where(a => a.Selection.CourseDate == DateTime.Now.AddDays(1).Date).ToList();
                        selectionStudents.ForEach(ss =>
                        {
                            if (ss.StudentInfo == null)
                            {
                                logger.Info($"课程提醒发送失败，选课记录{ss.SelectionStudentID}对应学员信息不存在");
                                return;
                            }
                            if (ss.Selection == null)
                            {
                                logger.Info($"课程提醒发送失败，选课记录{ss.SelectionStudentID}对应排课记录不存在");
                                return;
                            }
                            if (ss.StudentInfo.Family == null)
                            {
                                logger.Info($"课程提醒发送失败，学员{ss.StudentInfo.StudentID}对应家长信息不存在");
                                return;
                            }
                            if (ss.StudentInfo.Student == null)
                            {
                                logger.Info($"课程提醒发送失败，学员{ss.StudentInfo.StudentID}对应学员信息不存在");
                                return;
                            }
                            if (ss.Selection.Course == null)
                            {
                                logger.Info($"课程提醒发送失败，排课记录{ss.SelectionID}对应课程信息不存在");
                                return;
                            }
                            if (string.IsNullOrEmpty(ss.StudentInfo.Family.OpenId))
                            {
                                logger.Info($"课程提醒发送失败，家长{ss.StudentInfo.Family.FamilyID}未绑定微信");
                                return;
                            }
                            var data = new CourseReminderMessage(
                            "课程提醒", ss.Selection.Course.CourseName, ss.StudentInfo.Student.StudentName,
                            "更详细信息，请咨询HABA乐清中心");

                            var result = TemplateApi.SendTemplateMessageAsync(Config.SenparcWeixinSetting.WeixinAppId, ss.StudentInfo.Family.OpenId, data);
                            logger.Info($"发送课程提醒，结果：{result.Result.ToString()},");
                        });
                    }
                }
            });
        }
    }
}
