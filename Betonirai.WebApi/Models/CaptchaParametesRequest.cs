using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Betonirai.WebApi.Models
{
    public class CaptchaParametesRequest
    {
        public string RecaptchaChallengeField { get; set; }

        public string RecaptchaResponseField { get; set; }
    }
}