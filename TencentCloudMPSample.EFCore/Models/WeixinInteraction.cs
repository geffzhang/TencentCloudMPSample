using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TencentCloudMPSample.EFCore.Models
{
    public class WeixinInteraction
    {
        [Key]
        public int Id { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }
    }
}
