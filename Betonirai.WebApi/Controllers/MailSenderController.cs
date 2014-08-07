using Betonirai.WebApi.Business;
using Betonirai.WebApi.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Betonirai.WebApi.Controllers
{
    public class MailSenderController : BaseApiController
    {
        [HttpPost]
        [ActionName("SendMail")]
        public HttpResponseMessage SendMailWithCaptchaVerification(Mail mail)
        {
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

            var response = ReCaptcha.Instance.CheckCaptchaAsync(captchaParameters);
            string responseString = response.Result.ToString();
            string[] splittedByNewLine = responseString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            bool captchaResponse = bool.Parse(splittedByNewLine[0]);

            if (captchaResponse)
            {
                MailSender.Instance.SendMail(mail.Recipient, mail.Subject, mail.MessageBody, mail.BccRecipients);
                return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "successfully send mail" };
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = splittedByNewLine[1] };
        }
    }
}
