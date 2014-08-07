using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using Betonirai.WebApi.Models;

namespace Betonirai.WebApi.Business
{
    public sealed class ReCaptcha
    {
        private const string PrivateKey = "6LdRxfcSAAAAAGa8DtTyZ9rRS17zZZX_19KWumLx";
        private static readonly object SyncRoot = new object();
        private static ReCaptcha instance;

        public static ReCaptcha Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ReCaptcha();
                        }
                    }
                }

                return instance;
            }
        }

        public async Task<string> CheckCaptchaAsync(CaptchaParametes requestModel)
        {
            using (var client = new HttpClient())
            {
                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("privatekey", PrivateKey));
                values.Add(new KeyValuePair<string, string>("remoteip", requestModel.RemoteIP));
                values.Add(new KeyValuePair<string, string>("challenge", requestModel.Challenge));
                values.Add(new KeyValuePair<string, string>("response", requestModel.Response));
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://www.google.com/recaptcha/api/verify", content);
                string responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
    }
}