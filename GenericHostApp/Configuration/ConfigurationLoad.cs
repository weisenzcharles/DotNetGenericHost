using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenericHostApp.Configuration
{
    public static class ConfigurationLoad
    {
        public static IHostBuilder ConfigurationDirectoryLoad(this IHostBuilder hostBuilder, string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + path);
            if (!directoryInfo.Exists)
            {
                return hostBuilder;
            }

            FileInfo[] files = directoryInfo.GetFiles();
            List<FileInfo> filelist = files.Where((FileInfo s) => s.Name.EndsWith(".json")).ToList();
            return hostBuilder.ConfigureAppConfiguration(delegate (HostBuilderContext content, IConfigurationBuilder config)
            {
                filelist.ForEach(delegate (FileInfo s)
                {
                    config.AddJsonFile(s.FullName, optional: true, reloadOnChange: true);
                });
            });
        }
    }
}
