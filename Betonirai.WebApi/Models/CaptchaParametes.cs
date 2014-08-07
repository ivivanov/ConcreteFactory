using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Betonirai.WebApi.Models
{
    public class CaptchaParametes
    {
        public string RemoteIP { get; set; }

        public string Challenge { get; set; }

        public string Response { get; set; }
    }
}