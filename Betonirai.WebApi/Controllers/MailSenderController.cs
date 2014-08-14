using Betonirai.WebApi.Business;
using Betonirai.WebApi.Models;
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

            Logger.LogMessage(String.Format("{0}  {1}  {2} ", captchaParameters.Challenge, captchaParameters.Response, captchaParameters.RemoteIP));
            Task<string> response = null;

            try
            {
                response = ReCaptcha.Instance.CheckCaptchaAsync(captchaParameters);
            }
            catch (Exception ex)
            {
                Logger.LogExeption(ex);
            }

            string responseString = response.Result.ToString();
            string[] splittedByNewLine = responseString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            bool captchaResponse = bool.Parse(splittedByNewLine[0]);

            if (captchaResponse)
            {
                MailSender.Instance.SendMail(Recipient, Subject, mail.MessageBody, BccRecipients);
                return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "successfully send mail" };
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = splittedByNewLine[1] };
        }
    }
}
