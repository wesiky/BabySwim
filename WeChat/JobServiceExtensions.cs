using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Context;
using WeChat.Models;
using WeChat.Quartz;

namespace WeChat
{
    public static class JobServiceExtensions
    {
        public static IServiceCollection AddJobService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IJobCenter, JobCenter>();
            serviceCollection.BuildServiceProvider().RegisterServiceProvider();
            return serviceCollection;
        }
        /// <summary>
        /// 程序启动将任务调度表里所有状态为 执行中 任务启动起来
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static void RegisterJobs()
        {
            var jobCenter = ServiceCollectionExtension.Get<IJobCenter>();
            var dbContext = ServiceCollectionExtension.New<WeChatContext>();
            var jobInfoList = dbContext.TaskSchedules
                .Where(t => t.RunStatus.Equals((int)TaskJobStatus.DoJob))
                .Select(t => new TaskScheduleModel
                {
                    Id = t.Id,
                    JobGroup = t.JobGroup,
                    JobName = t.JobName,
                    CronExpress = t.CronExpress,
                    StarRunTime = t.StarRunTime,
                    EndRunTime = t.EndRunTime,
                    NextRunTime = t.NextRunTime,
                    RunStatus = t.RunStatus
                }).ToList();

            jobInfoList.ForEach(async t =>
            {
                await jobCenter.AddScheduleJobAsync(t);
            });
        }
    }
}
