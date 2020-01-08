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
                    //ʹ��autofac����
                    .AddControllersAsServices();

            services.AddDistributedMemoryCache();
            services.AddDbContext<WeChatContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WeChatContext")));


            /*
             * CO2NET �Ǵ� Senparc.Weixin ����ĵײ㹫������ģ�飬�����˳��� 6 ��ĵ����Ż����ȶ��ɿ���
             * ���� CO2NET ��������Ŀ�е�ͨ�����ÿɲο� CO2NET �� Sample��
             * https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore/Startup.cs
             */

            services.AddSenparcGlobalServices(Configuration)//Senparc.CO2NET ȫ��ע��
                    .AddSenparcWeixinServices(Configuration);//Senparc.Weixin ע��

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

            // ���� CO2NET ȫ��ע�ᣬ���룡
            // ���� UseSenparcGlobal() �ĸ����÷��� CO2NET Demo��https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore3/Startup.cs
            var registerService = app.UseSenparcGlobal(env, senparcSetting.Value, globalRegister =>
            {
                #region ע����־

                globalRegister.RegisterTraceLog(ConfigTraceLog);//����TraceLog

                #endregion
            }, true)
                //ʹ�� Senparc.Weixin SDK
                .UseSenparcWeixin(senparcWeixinSetting.Value, weixinRegister =>
                {
                });

            //ȫ��ֻ��ע��һ��
            AccessTokenContainer.RegisterAsync(Senparc.Weixin.Config.SenparcWeixinSetting.WeixinAppId, Senparc.Weixin.Config.SenparcWeixinSetting.WeixinAppSecret);

            JobServiceExtensions.RegisterJobs();
        }

        /// <summary>
        /// ����΢�Ÿ�����־
        /// </summary>
        private void ConfigTraceLog()
        {
            //������ΪDebug״̬ʱ��/App_Data/WeixinTraceLog/Ŀ¼�»�������־�ļ���¼���е�API������־����ʽ�����汾����ر�

            //���ȫ�ֵ�IsDebug��Senparc.CO2NET.Config.IsDebug��Ϊfalse���˴����Ե�������true�������Զ�Ϊtrue
            Senparc.CO2NET.Trace.SenparcTrace.SendCustomLog("ϵͳ��־", "ϵͳ����");//ֻ��Senparc.Weixin.Config.IsDebug = true���������Ч

            //ȫ���Զ�����־��¼�ص�
            Senparc.CO2NET.Trace.SenparcTrace.OnLogFunc = () =>
            {
                //����ÿ�δ���Log����Ҫִ�еĴ���
            };
        }

        /// <summary>
        /// ����autofac����
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // ��������ӷ���ע��
            Assembly assembly = Assembly.GetExecutingAssembly();

            //ע��洢��
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Reponsitory"))
                   .AsImplementedInterfaces()
                   .PropertiesAutowired();


            //ע��ҵ�����
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .PropertiesAutowired();//��������ע��
        }
    }
}
