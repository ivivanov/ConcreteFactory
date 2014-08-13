using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Betonirai.WebApi.Models
{
    public class Mail
    {
        //public string Recipient { get; set; }

        //public string Subject { get; set; }

        public string MessageBody { get; set; }

        public string SenderMail { get; set; }

        //public IEnumerable<string> BccRecipients { get; set; }

        public string recaptcha_challenge_field { get; set; }

        public string recaptcha_response_field { get; set; }

        //public string RemoteIP { get; set; }
    }
}