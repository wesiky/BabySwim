using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Models;

namespace WeChat.Quartz
{
    public interface IJobCenter
    {
        /// <summary>
        /// 添加定时任务
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        Task<QuartzResult> AddScheduleJobAsync(TaskScheduleModel m);

        /// <summary>
        /// 暂停定时任务
        /// </summary>
        /// <param name="jobGroup"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        Task<QuartzResult> StopScheduleJobAsync(string jobGroup, string jobName);

        /// <summary>
        /// 恢复定时任务
        /// </summary>
        /// <param name="jobGroup"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        Task<QuartzResult> RunScheduleJobAsync(TaskScheduleModel m);
    }
}
