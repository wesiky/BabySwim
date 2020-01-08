using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Models;

namespace WeChat.Context
{
    public class WeChatContext : DbContext
    {
        public WeChatContext(DbContextOptions<WeChatContext> options)
            : base(options)
        {
        }

        public DbSet<AssistNotice> AssistNotices { get; set; }

        public DbSet<BaseCourse> Courses { get; set; }

        public DbSet<BaseCustomerInfo> CustomerInfos { get; set; }

        public DbSet<BaseFamily> Families { get; set; }

        public DbSet<BaseStudent> Students { get; set; }

        public DbSet<BaseStudentInfo> StudentInfos { get; set; }

        public DbSet<BaseTeacher> Teachers { get; set; }

        public DbSet<CourseConfirmedStudent> ConfirmedStudents { get; set; }

        public DbSet<CourseEvaluate> Evaluates { get; set; }

        public DbSet<CourseScheduler> Scheduler { get; set; }

        public DbSet<CourseSelection> Selections { get; set; }

        public DbSet<CourseSelectionStudent> SelectionStudents { get; set; }

        public virtual DbSet<TaskSchedule> TaskSchedules { get; set; }
    }
}
