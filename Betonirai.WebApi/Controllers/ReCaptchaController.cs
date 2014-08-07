using Betonirai.WebApi.Business;
using Betonirai.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Betonirai.WebApi.Controllers
{
    public class ReCaptchaController : BaseApiController
    {
        [HttpPost]
        public bool CheckReCapthca(CaptchaParametesRequest requst)
        {
           
            CaptchaParametes captchaParameters = new CaptchaParametes();
            //TODO map captchaParameters
            var response = ReCaptcha.Instance.CheckCaptchaAsync(captchaParameters);
            string responseString = response.Result.ToString();
            string[] splittedByNewLine = responseString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            return bool.Parse(splittedByNewLine[0]);
        }
    }
}