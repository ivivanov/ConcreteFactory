using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Betonirai.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //enforce this filter over the entire Web API
            //config.Filters.Add(new ForceHttpsAttribute());

            //CORS http://stackoverflow.com/questions/18347290/webapi-odata-5-0-beta-accessing-globalconfiguration-throws-security-error
            // https://github.com/PDMLab/WebApiCorsSample/blob/master/CorsApiServer/Web.config
            // http://blogs.msdn.com/b/yaohuang1/archive/2013/04/05/try-out-asp.net-web-api-cors-support-using-the-nightly-builds.aspx
            //PM> Install-Package Microsoft.AspNet.WebApi.Cors -Version 5.0.0
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            //config.MessageHandlers.Add(new TokenAuthenticationHandler());

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
        }
    }
}
