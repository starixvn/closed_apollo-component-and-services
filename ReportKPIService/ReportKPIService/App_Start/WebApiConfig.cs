using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ReportKPIService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "ReportKPI",
                routeTemplate: "api/{controller}/ReportKPI/{id}",
                defaults: new { Controllers = "kpi", Action = "ReportKPI", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "ReportSunSportWinLoss",
               routeTemplate: "api/{controller}/ReportSunSportWinLoss/{id}",
               defaults: new { Controllers = "kpi", Action = "ReportSunSportWinLoss", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "ReportTopSportAll",
               routeTemplate: "api/{controller}/ReportTopSportAll/{id}",
               defaults: new { Controllers = "kpi", Action = "ReportTopSportAll", id = RouteParameter.Optional }
           );
        }
    }
}
