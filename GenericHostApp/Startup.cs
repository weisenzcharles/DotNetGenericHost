using GenericHostApp.HostedService;
using GenericHostApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericHostApp
{
    public class Startup
    {
        /// <summary>
        /// 初始化 <see cref="Startup"/> 类的新实例。
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置文件。
        /// </summary>
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // inject some settings
            services.Configure<AppSettingsModel>(
                Configuration.GetSection("AppSettings"));

            // inject an IHostedService that depends on the above settings
            services.AddHostedService<CountSheepService>();

            // inject a BackgroundService
            //services.AddHostedService<SheepQueueService>();

            // inject some transient services
            services.AddTransient<IDadJokeService, DadJokeService>();
            services.AddTransient<ISheepQueueService, SheepQueueService>();

            // inject a singleton
            services.AddSingleton<ISheepStorageService, SheepStorageService>();

            // add in an IHttpClientFactory
            services.AddHttpClient();

            // add in IMemoryCache
            services.AddMemoryCache();
        }
    }
}
