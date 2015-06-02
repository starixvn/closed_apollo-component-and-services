// --------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.30">Created</change>
// </history>
namespace ApolloReportKPIService
{
    using System.Web.Http;

    /// <summary>
    /// Web API config class.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                 name: "ReportKPI",
                 routeTemplate: "api/{controller}/ReportKPI/{id}",
                 defaults: new { Controllers = "kpi", Action = "ReportKPI", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
               name: "ReportSunSportWinLoss",
               routeTemplate: "api/{controller}/ReportSunSportWinLoss/{id}",
               defaults: new { Controllers = "kpi", Action = "ReportSunSportWinLoss", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
               name: "LAReportSunSportWinLoss",
               routeTemplate: "api/{controller}/LAReportSunSportWinLoss/{id}",
               defaults: new { Controllers = "kpi", Action = "LAReportSunSportWinLoss", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
               name: "ReportTopSportAll",
               routeTemplate: "api/{controller}/ReportTopSportAll/{id}",
               defaults: new { Controllers = "kpi", Action = "ReportTopSportAll", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
              name: "GetCurrency",
              routeTemplate: "api/{controller}/GetCurrency/{id}",
              defaults: new { Controllers = "kpi", Action = "GetCurrency", id = RouteParameter.Optional });
        }
    }
}