using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat
{
    public static class HostBuilder
    {

        public static void ProgramMain(Action main)
        {
            main();
        }

        /// <summary>
        /// 加入自定义默认配置
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IHostBuilder CreateDefaultBuilder(this IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureAppConfiguration(
                (ctx, config) => ConfigLocator.SetLocatorProvider(new ConfigGeter(config.Build())))
                .ConfigureServices((ctx, services) =>
                {
                    services
                    .AddRegisterContainer();
                });
    }
}
