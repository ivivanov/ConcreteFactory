using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using Betonirai.WebApi.Models;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using Recaptcha;

namespace Betonirai.WebApi.Business
{
    public sealed class ReCaptcha
    {
        private const string PrivateKey = "";
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

        public bool CheckCaptcha(CaptchaParametes requestModel)
        {
            Uri address = new Uri("http://www.google.com/recaptcha/api/verify");

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST  
            request.Method = "POST";
            request.ContentType = "application/json";

            object values = new { privatekey = PrivateKey, remoteip = requestModel.RemoteIP, challenge = requestModel.Challenge, response = requestModel.Response };
            
            // Create the data we want to send
            string json = new JavaScriptSerializer().Serialize(values);

            // Create a byte array of the data we want to send  
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

            // Set the content length in the request headers  
            request.ContentLength = byteData.Length;

            // Write data  
            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output  
                Console.WriteLine(reader.ReadToEnd());
            }

            return true;
        }

        public RecaptchaResponse Validate(CaptchaParametes requestModel)
        {
            RecaptchaValidator validator = new RecaptchaValidator();
            validator.Challenge = requestModel.Challenge;
            validator.PrivateKey = PrivateKey;
            validator.RemoteIP = requestModel.RemoteIP;
            validator.Response = requestModel.Response;

            RecaptchaResponse response = validator.Validate();

            return response;
        }
    }
}