using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using TencentCloud.Tmt.V20180321;
using TencentCloud.Tmt.V20180321.Models;

namespace MachineTranslation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineTranslationController : ControllerBase
    {
        private readonly TmtClient _client;

        public MachineTranslationController(TmtClient client)
        {
            _client = client;
        }

        [HttpPost("Image")]
        public async Task<ImageTranslateResponse> ImageTranslate([FromBody]ImageTranslateRequest request)
        {
            var result = await _client.ImageTranslate(request);
            return result;
        }

        [HttpPost("LanguageDetect")]
        public async Task<LanguageDetectResponse> LanguageDetect([FromBody]LanguageDetectRequest request)
        {
            var result = await _client.LanguageDetect(request);
            return result;
        }

        [HttpPost("Speech")]
        public async Task<SpeechTranslateResponse> SpeechTranslate([FromBody]SpeechTranslateRequest request)
        {
            try
            {
                Console.WriteLine($"request: { JsonConvert.SerializeObject(request)}");
                var result = await _client.SpeechTranslate(request);
                Console.WriteLine($"response: { JsonConvert.SerializeObject(result)}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\r\n{ex.StackTrace}\r\n{ex.Source}");
                throw ex;
            }
        }

        [HttpPost("Text")]
        public async Task<TextTranslateResponse> TextTranslate([FromBody]TextTranslateRequest request)
        {
            var langRequest = new LanguageDetectRequest
            {
                Text = request.SourceText,
                ProjectId = request.ProjectId
            };
            var langResponse = await _client.LanguageDetect(langRequest);
            if (langResponse.Lang.Equals("en"))
            {
                request.Target = "zh";
            }
            else if (langResponse.Lang.Equals("zh"))
            {
                request.Target = "en";
            }
            else
            {
                request.Target = "zh";
            }
            Console.WriteLine($"request: { JsonConvert.SerializeObject(request)}");
            var result = await _client.TextTranslate(request);
            Console.WriteLine($"response: { JsonConvert.SerializeObject(result)}");
            return result;
        }
    }
}
