using Betonirai.WebApi.Business;
using Betonirai.WebApi.Models;
using Recaptcha;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Betonirai.WebApi.Controllers
{
    public class MailSenderController : BaseApiController
    {
        const string Recipient = "ivanivanov12@gmail.com";
        const string Subject = "Web Api mail";

        public IEnumerable<string> BccRecipients { get; set; }

        [HttpPost]
        [ActionName("SendMail")]
        public HttpResponseMessage SendMailWithCaptchaVerification(Mail mail)
        {
            if (String.IsNullOrEmpty(mail.MessageBody))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "no message"};
            }
            if (String.IsNullOrEmpty(mail.SenderMail))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "no sender" };
            }

            string ip = HttpContext.Current.Request.UserHostAddress;
            //string ip = String.Empty;
            //if (this.ControllerContext.Request.Properties.ContainsKey("MS_HttpContext"))
            //{
            //    var ctx = this.ControllerContext.Request.Properties["MS_HttpContext"] as HttpContextWrapper;
            //    if (ctx != null)
            //    {
            //        ip = ctx.Request.UserHostAddress;
            //    }
            //}

            CaptchaParametes captchaParameters = new CaptchaParametes();
            captchaParameters.Challenge = mail.recaptcha_challenge_field;
            captchaParameters.Response = mail.recaptcha_response_field;
            captchaParameters.RemoteIP = ip;

            RecaptchaResponse recaptcha = ReCaptcha.Instance.Validate(captchaParameters);

            if (recaptcha.IsValid)
            {
                MailSender.Instance.SendMail(Recipient, Subject, mail.MessageBody, BccRecipients);
                return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "successfully send mail" };
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = recaptcha.ErrorMessage};
        }
    }
}
