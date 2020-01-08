using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.RegisterServices;
using Senparc.CO2NET;
using Senparc.Weixin;
using Senparc.Weixin.MP.Containers;
using WeChat.Context;
using Senparc.Weixin.Entities;
using Microsoft.Extensions.Options;
using Autofac;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Quartz;
using Quartz.Impl;
using Autofac.Extensions.DependencyInjection;
using WeChat.Quartz;

namespace WeChat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddControllersWithViews()
                    //使用autofac所需
                    .AddControllersAsServices();

            services.AddDistributedMemoryCache();
            services.AddDbContext<WeChatContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WeChatContext")));


            /*
             * CO2NET 是从 Senparc.Weixin 分离的底层公共基础模块，经过了长达 6 年的迭代优化，稳定可靠。
             * 关于 CO2NET 在所有项目中的通用设置可参考 CO2NET 的 Sample：
             * https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore/Startup.cs
             */

            services.AddSenparcGlobalServices(Configuration)//Senparc.CO2NET 全局注册
                    .AddSenparcWeixinServices(Configuration);//Senparc.Weixin 注册

            //services.AddSingleton<ScheduleCenter>();

            //quartz
            services.AddJobService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // 启动 CO2NET 全局注册，必须！
            // 关于 UseSenparcGlobal() 的更多用法见 CO2NET Demo：https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore3/Startup.cs
            var registerService = app.UseSenparcGlobal(env, senparcSetting.Value, globalRegister =>
            {
                #region 注册日志

                globalRegister.RegisterTraceLog(ConfigTraceLog);//配置TraceLog

                #endregion
            }, true)
                //使用 Senparc.Weixin SDK
                .UseSenparcWeixin(senparcWeixinSetting.Value, weixinRegister =>
                {
                });

            //全局只需注册一次
            AccessTokenContainer.RegisterAsync(Senparc.Weixin.Config.SenparcWeixinSetting.WeixinAppId, Senparc.Weixin.Config.SenparcWeixinSetting.WeixinAppSecret);

            JobServiceExtensions.RegisterJobs();
        }

        /// <summary>
        /// 配置微信跟踪日志
        /// </summary>
        private void ConfigTraceLog()
        {
            //这里设为Debug状态时，/App_Data/WeixinTraceLog/目录下会生成日志文件记录所有的API请求日志，正式发布版本建议关闭

            //如果全局的IsDebug（Senparc.CO2NET.Config.IsDebug）为false，此处可以单独设置true，否则自动为true
            Senparc.CO2NET.Trace.SenparcTrace.SendCustomLog("系统日志", "系统启动");//只在Senparc.Weixin.Config.IsDebug = true的情况下生效

            //全局自定义日志记录回调
            Senparc.CO2NET.Trace.SenparcTrace.OnLogFunc = () =>
            {
                //加入每次触发Log后需要执行的代码
            };
        }

        /// <summary>
        /// 配置autofac容器
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // 在这里添加服务注册
            Assembly assembly = Assembly.GetExecutingAssembly();

            //注册存储层
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Reponsitory"))
                   .AsImplementedInterfaces()
                   .PropertiesAutowired();


            //注册业务服务
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .PropertiesAutowired();//允许属性注入
        }
    }
}
