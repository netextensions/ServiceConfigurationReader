using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ServiceConfigurationReader
{
    public class ServiceConfigurationReader
    {
        public IConfiguration Configuration(params string[] jsonFileNames)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(((Func<string>)(() =>
                            {
                                var processModule = Process.GetCurrentProcess().MainModule;
                                return processModule != null ? Path.GetDirectoryName(processModule.FileName) : throw new ApplicationException("processModule is not found");
                            }
                        )
                    )())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                .AddEnvironmentVariables();

            foreach (var fileName in jsonFileNames)
                builder.AddJsonFile(fileName);


            return builder.Build();
        }
    }
}
