using Microsoft.Extensions.Configuration;
using System;

namespace ServiceConfigurationReader
{
    public class ServiceConfigurationReader
    {
        public IConfiguration Configuration(params string[] jsonFileNames)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(new ServiceContentRoot.ServiceContentRoot().GetContentRoot())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                .AddEnvironmentVariables();

            foreach (var fileName in jsonFileNames)
                builder.AddJsonFile(fileName);


            return builder.Build();
        }
    }
}
