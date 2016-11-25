using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BcApiFrame.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new Log.Filter_ApiRecord.Filter_ApiRecord());
            config.Filters.Add(new Log.Filter_ErrorRecord.ApiHandleErrorAttribute());

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
