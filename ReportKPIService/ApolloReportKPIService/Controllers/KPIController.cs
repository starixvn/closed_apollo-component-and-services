// --------------------------------------------------------------------------
// <copyright file="KPIController.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.30">Created</change>
// </history>
namespace ApolloReportKPIService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;
    using ApolloReportKPIService.Models;

    public class KPIController : ApiController
    {
        private HttpClient client = null;
        private string urlService = string.Empty;

        public KPIController()
        {
            client = new HttpClient();
            urlService = ConfigurationManager.AppSettings["URLService"].ToString();
        }

        [HttpGet]
        public IEnumerable<CurrencyModel> GetCurrency()
        {
            return GetData<CurrencyModel>("api/kpi/getcurrency");
        }

        [HttpGet]
        public IEnumerable<KPIModel> ReportKPI(DateTime reportDate)
        {
            return GetData<KPIModel>("api/kpi/ReportKPI?reportdate=" + reportDate);
        }

        [HttpGet]
        public IEnumerable<TopSportAllModel> ReportTopSportAll(DateTime reportDate)
        {
            return GetData<TopSportAllModel>("api/kpi/ReportTopSportAll?reportdate=" + reportDate);
        }

        [HttpGet]
        public IEnumerable<SunSportWinLossModel> ReportSunSportWinLoss(
            DateTime fromDate,
            DateTime toDate,
            int currency = 0,
            short drawType = 0,
            short reportBy = 0)
        {

            return GetData<SunSportWinLossModel>(
                "api/kpi/ReportSunSportWinLoss?fromDate=" + fromDate +
                "&toDate=" + toDate +
                "&currency=" + currency +
                "&drawType=" + drawType +
                "&reportBy=" + reportBy);
        }

        private IEnumerable<T> GetData<T>(string url)
        {
            client.BaseAddress = new Uri(urlService);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                if (data != null && data.Any())
                {
                    return data;
                }
            }

            return new List<T>();
        }

    }
}