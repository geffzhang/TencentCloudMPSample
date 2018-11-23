using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Enums;
using Xabe.FFmpeg.Exceptions;
using Xabe.FFmpeg.Model;
using Xabe.FFmpeg.Streams;

namespace TencentCloudMPSample.Utilities
{
    public static class FFmpegUtil
    {
        public static async Task<bool> Arm2Mp3Async(string inputPath,string outPutPath)
        {
            try
            {
                IConversionResult conversionResult = await Conversion
                .New()
                .AddParameter($"-i {inputPath}")
                .SetOutput(outPutPath)
                .Start();
                return conversionResult.Success;
            }catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}\r\n{ex.Source}\r\n{ex.StackTrace}");
                return false;
            }
            
        }

        public static void InitFFmpeg()
        {
            if (File.Exists("/app/ffmpeg"))
            {
                Console.WriteLine("ffmpeg already exists");
                var psi = new ProcessStartInfo("chmod", "+x /app/ffmpeg");
                var psi2 = new ProcessStartInfo("chmod", "+x /app/ffprobe");
                //启动
                Process.Start(psi);
                //启动 
                Process.Start(psi2);
            }
            else
            {
                FFmpeg.GetLatestVersion().ConfigureAwait(false).GetAwaiter().GetResult();
                var psi = new ProcessStartInfo("chmod", "+x /app/ffmpeg");
                var psi2 = new ProcessStartInfo("chmod", "+x /app/ffprobe");
                //启动
                Process.Start(psi);
                //启动 
                Process.Start(psi2);
            }
            
        }
    }
}
