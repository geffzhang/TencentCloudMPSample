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
    public class IntelligentVoiceServer : IDisposable
    {
        private readonly HttpClient client;

        public IntelligentVoiceServer()
        {
            this.client = GetHttpClient();
        }

        public async Task<string> Voice2Text(string voicePath)
        {
            var fileStream = new FileStream(voicePath, FileMode.Open);
            byte[] bytes = StreamUtil.Stream2Byte(fileStream);

            HttpContent content = new StringContent(JsonConvert.SerializeObject(new
            {
                SourceType = 1,
                EngSerViceType = "8k",
                SubServiceType = 2,
                ProjectId = 0,
                Data = Convert.ToBase64String(bytes),
                DataLen = bytes.Length,
                VoiceFormat = "mp3",
                UsrAudioKey = Guid.NewGuid().ToString("N")
            }));
            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/json");
            try
            {
                var response = await client.PostAsync("api/IntelligentVoice/SentenceRecognition", content, default(CancellationToken));
                var dy = await response.Content.ReadAsAsync<dynamic>();
                return dy.Result;
            }
            catch (Exception ex)
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
            client.BaseAddress = new Uri("http://intelligent-voice/");
            return client;
        }

    }
}
