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

    /// <summary>
    /// KPI Controller class.
    /// </summary>
    public class KPIController : ApiController
    {
        private HttpClient _client = null;
        private string _urlService = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="KPIController"/> class.
        /// </summary>
        public KPIController()
        {
            _client = new HttpClient();
            _urlService = ConfigurationManager.AppSettings["URLService"].ToString();
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <returns>List of currency.</returns>
        [HttpGet]
        public IEnumerable<dynamic> GetCurrency()
        {
            return GetListData<dynamic>("api/kpi/getcurrency");
        }

        /// <summary>
        /// Reports the KPI.
        /// </summary>
        /// <param name="reportDate">The report date.</param>
        /// <returns>List of KPI.</returns>
        [HttpGet]
        public IEnumerable<dynamic> ReportKPI(DateTime reportDate)
        {
            return GetListData<dynamic>("api/kpi/ReportKPI?reportdate=" + reportDate);
        }

        /// <summary>
        /// Reports the top sport all.
        /// </summary>
        /// <param name="reportDate">The report date.</param>
        /// <returns>List of top sport.</returns>
        [HttpGet]
        public IEnumerable<dynamic> ReportTopSportAll(DateTime reportDate)
        {
            return GetListData<dynamic>("api/kpi/ReportTopSportAll?reportdate=" + reportDate);
        }

        /// <summary>
        /// Reports the sun sport win loss.
        /// </summary>
        /// <param name="fromDate">Input from date.</param>
        /// <param name="toDate">Input to date.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="drawType">Type of the draw.</param>
        /// <param name="reportBy">The report by.</param>
        /// <returns>List of sun sport win loss.</returns>
        [HttpGet]
        public dynamic ReportSunSportWinLoss(
            DateTime fromDate,
            DateTime toDate,
            int currency = 0,
            short drawType = 0,
            short reportBy = 0)
        {
            string url = "api/kpi/ReportSunSportWinLoss?fromDate=" + fromDate +
                    "&toDate=" + toDate +
                    "&currency=" + currency +
                    "&drawType=" + drawType +
                    "&reportBy=" + reportBy;
            _client.BaseAddress = new Uri(_urlService);
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = _client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsAsync<dynamic>().Result;
                if (data != null)
                {
                    return data;
                }
            }

            return null;
        }

        /// <summary>
        /// LA the report sun sport win loss.
        /// </summary>
        /// <param name="fromDate">The From date.</param>
        /// <param name="toDate">The To date.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="drawType">Type of the draw.</param>
        /// <param name="reportBy">The report by.</param>
        /// <param name="baseCurrency">The base currency.</param>
        /// <returns>List of sun sport win loss.</returns>
        [HttpGet]
        public IEnumerable<dynamic> LAReportSunSportWinLoss(
           DateTime fromDate,
           DateTime toDate,
           int currency = 0,
           short drawType = 0,
           short reportBy = 0,
            byte baseCurrency = 0)
        {
            string url = "api/kpi/LAReportSunSportWinLoss?fromDate=" + fromDate +
                    "&toDate=" + toDate +
                    "&currency=" + currency +
                    "&drawType=" + drawType +
                    "&reportBy=" + reportBy +
                    "&basecurrency=" + baseCurrency;

            return GetListData<dynamic>(url);
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <typeparam name="T">The object model.</typeparam>
        /// <param name="url">Input the URL.</param>
        /// <returns>List of object.</returns>
        private IEnumerable<T> GetListData<T>(string url)
        {
            _client.BaseAddress = new Uri(_urlService);
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = _client.GetAsync(url).Result;

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