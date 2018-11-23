using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TencentCloud.Aai.V20180522;
using TencentCloud.Common;
using TencentCloud.Common.Profile;

namespace MachineTranslation.Extensions
{
    public static class TencentCloudExtension
    {
        public static void AddTencentCloud(this IServiceCollection services)
        {
            var cred = new Credential
            {
                SecretId = Environment.GetEnvironmentVariable("TENCENTCLOUD_SECRET_ID"),
                SecretKey = Environment.GetEnvironmentVariable("TENCENTCLOUD_SECRET_KEY")
            };
            var clientProfile = new ClientProfile();
            var httpProfile = new HttpProfile();
            httpProfile.Endpoint = ("aai.tencentcloudapi.com");
            clientProfile.HttpProfile = httpProfile;

            var client = new AaiClient(cred, "ap-guangzhou", clientProfile);

            services.AddScoped<AaiClient>(sp => client);
        }
    }
}
