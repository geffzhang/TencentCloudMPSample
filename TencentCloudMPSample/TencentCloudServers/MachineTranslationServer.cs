using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TencentCloudMPSample.Utilities;

namespace TencentCloudMPSample.TencentCloudServers
{
    public class MachineTranslationServe : IDisposable
    {
        private readonly HttpClient client;
        public MachineTranslationServe()
        {
            client = GetHttpClient();
        }

        public async Task<string> TextTranslate(string text)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(new {
                SourceText = text,
                Source = "auto",
                Target = "zh",
                ProjectId = 1
            }));
            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/json");
            try {
                var response = await client.PostAsync("api/MachineTranslation/Text", content, default(CancellationToken));
                var dy = await response.Content.ReadAsAsync<dynamic>();
                return dy.TargetText;
            }catch(Exception ex)
            {
                return $"{ex.Message}\r\n{ex.StackTrace}\r\n{ex.Source}";
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }

        private static HttpClient GetHttpClient()
        {
            var client = HttpClientFactory.Create();
            client.BaseAddress = new Uri("http://machine-translation/");
            return client;
        }
    }
}
