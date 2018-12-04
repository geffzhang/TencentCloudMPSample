using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kubernetes.Configuration.Extensions.Configmap;
using Kubernetes.Configuration.Extensions.Secret;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TencentCloudMPSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration((hostingContext, config) =>
                //{
                //    config.AddKubernetesConfigmap("qcloud-app:mp", namespaceSelector: "qcloud", reloadOnChange: true);
                //    config.AddKubernetesSecret("qcloud-app:mp", namespaceSelector: "qcloud", reloadOnChange: true);

                //})
                .UseStartup<Startup>();
    }
}
