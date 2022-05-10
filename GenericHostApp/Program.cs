using GenericHostApp.Configuration;
using GenericHostApp.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace GenericHostApp
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigurationDirectoryLoad("\\config\\")
            .UseStartup<Startup>();

    }
}
