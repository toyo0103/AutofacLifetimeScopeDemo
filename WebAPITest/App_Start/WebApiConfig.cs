using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPITest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            // 註冊Handler
            var delegatingHandlers = DependencyResolver.Current.GetServices<DelegatingHandler>();
            foreach (var delegatingHandler in delegatingHandlers)
            {
                config.MessageHandlers.Add(delegatingHandler);
            }

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
