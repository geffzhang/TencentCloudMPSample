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

        [MaxLength(1000)]
        public string Request { get; set; }

        [MaxLength(1000)]
        public string Response { get; set; }
    }
}
