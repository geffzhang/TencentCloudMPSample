using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TencentCloud.Aai.V20180522;
using TencentCloud.Aai.V20180522.Models;

namespace MachineTranslation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntelligentVoiceController : ControllerBase
    {
        private readonly AaiClient _client;

        public IntelligentVoiceController(AaiClient client)
        {
            _client = client;
        }

        [HttpPost("SentenceRecognition")]
        public async Task<SentenceRecognitionResponse> SentenceRecognition(SentenceRecognitionRequest request)
        {
            Console.WriteLine($"request: { JsonConvert.SerializeObject(request)}");
            var result = await _client.SentenceRecognition(request);
            Console.WriteLine($"response: { JsonConvert.SerializeObject(result)}");
            return result;
        }

        [HttpPost("TextToVoice")]
        public async Task<TextToVoiceResponse> TextToVoice(TextToVoiceRequest request)
        {
            var result = await _client.TextToVoice(request);
            return result;
        }

        [HttpPost("SimultaneousInterpreting")]
        public async Task<SimultaneousInterpretingResponse> SimultaneousInterpreting(SimultaneousInterpretingRequest request)
        {
            var result = await _client.SimultaneousInterpreting(request);
            return result;
        }

        [HttpPost("Chat")]
        public async Task<ChatResponse> Chat(ChatRequest request)
        {
            var result = await _client.Chat(request);
            return result;
        }
    }
}
