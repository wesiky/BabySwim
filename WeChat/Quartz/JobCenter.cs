using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.IServices;
using WeChat.Models;
using WeChat.Models.Result;

namespace WeChat.Quartz
{
    /// <summary>
    /// 任务调度中心
    /// </summary>
    public class JobCenter : IJobCenter
    {

        public static IScheduler scheduler = null;
        public static async Task<IScheduler> GetSchedulerAsync()
        {
            if (scheduler != null)
            {
                return scheduler;
            }
            else
            {
                ISchedulerFactory schedf = new StdSchedulerFactory();
                IScheduler sched = await schedf.GetScheduler();
                return sched;
            }
        }
        /// <summary>
        /// 添加任务计划//或者进程终止后的开启
        /// </summary>
        /// <returns></returns>
        public async Task<QuartzResult> AddScheduleJobAsync(TaskScheduleModel m)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            QuartzResult result = new QuartzResult();
            try
            {
                if (m != null)
                {
                    DateTimeOffset starRunTime = DateBuilder.NextGivenSecondDate(m.StarRunTime, 1);
                    DateTimeOffset endRunTime = DateBuilder.NextGivenSecondDate(m.EndRunTime, 1);
                    scheduler = await GetSchedulerAsync();
                    IJobDetail job = JobBuilder.Create(typeof(HttpJob))
                      .WithIdentity(m.JobName, m.JobGroup)
                      //.SetJobData("service",_weChatService)
                      .Build();
                    ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                                 //.StartAt(m.StarRunTime)
                                                 .WithIdentity(m.JobName, m.JobGroup)
                                                 .WithCronSchedule(m.CronExpress)
                                                 .Build();
                    //如果已存在相同任务删除
                    if (await scheduler.CheckExists(job.Key))
                    {
                        await scheduler.DeleteJob(job.Key);
                    }
                    await scheduler.ScheduleJob(job, trigger);
                    await scheduler.Start();
                    logger.Info($"启动定时任务{m.JobGroup}-{m.JobName}");
                    result.Data = m;
                    return result;
                }
                return result.SetError("传入实体为空");
            }
            catch (Exception ex)
            {
                logger.Error($"[JobCenter_AddScheduleJobAsync]_{ex}");
                return result.SetError(ex.Message);
            }
        }

        /// <summary>
        /// 暂停指定任务计划
        /// </summary>
        /// <returns></returns>
        public async Task<QuartzResult> StopScheduleJobAsync(string jobGroup, string jobName)
        {
            QuartzResult result = new QuartzResult();
            try
            {
                scheduler = await GetSchedulerAsync();
                //使任务暂停
                await scheduler.PauseJob(new JobKey(jobName, jobGroup));
                var status = new BaseResult()
                {
                    ResultCode = 0,
                    ResultMsg = "暂停任务计划成功",
                };
                result.Data = status;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[JobCenter_StopScheduleJobAsync]_{ex}");
                var status = new BaseResult()
                {
                    ResultCode = -1,
                    ResultMsg = "暂停任务计划失败",
                };
                result.Data = status;
                return result;
            }
        }
        /// <summary>
        /// 恢复指定的任务计划**恢复的是暂停后的任务计划，如果是程序奔溃后 或者是进程杀死后的恢复，此方法无效
        /// </summary>
        /// <returns></returns>
        public async Task<QuartzResult> RunScheduleJobAsync(TaskScheduleModel sm)
        {
            QuartzResult result = new QuartzResult();
            try
            {
                #region 开任务
                //scheduler = await GetSchedulerAsync();
                //DateTimeOffset starRunTime = DateBuilder.NextGivenSecondDate(sm.StarRunTime, 1);
                //DateTimeOffset endRunTime = DateBuilder.NextGivenSecondDate(sm.EndRunTime, 1);
                //IJobDetail job = JobBuilder.Create<HttpJob>()
                //  .WithIdentity(sm.JobName, sm.JobGroup)
                //  .Build();
                //ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                //                             .StartAt(starRunTime)
                //                             .EndAt(endRunTime)
                //                             .WithIdentity(sm.JobName, sm.JobGroup)
                //                             .WithCronSchedule(sm.CronExpress)
                //                             .Build();
                //await scheduler.ScheduleJob(job, trigger);
                //await scheduler.Start();
                #endregion
                scheduler = await GetSchedulerAsync();
                //resumejob 恢复
                await scheduler.ResumeJob(new JobKey(sm.JobName, sm.JobGroup));

                var status = new BaseResult()
                {
                    ResultCode = 0,
                    ResultMsg = "恢复任务计划成功",
                };
                result.Data = status;
                return result;
            }
            catch (Exception ex)
            {
                Console.Write($"[JobCenter_RunScheduleJobAsync]_{ex}");
                var status = new BaseResult()
                {
                    ResultCode = -1,
                    ResultMsg = "恢复任务计划失败",
                };
                result.Data = status;
                return result;
            }
        }
    }
}
