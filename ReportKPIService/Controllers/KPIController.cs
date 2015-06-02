// --------------------------------------------------------------------------
// <copyright file="KPIController.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.24">Created</change>
// </history>
namespace Apollo.ReportKPIService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Apollo.ReportKPIService.Services;

    /// <summary>
    /// KPI controller class.
    /// </summary>
    public class KPIController : ApiController
    {
        private KPIService _reportKPIService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="KPIController"/> class.
        /// </summary>
        public KPIController()
        {
            _reportKPIService = new KPIService();
        }

        /// <summary>
        /// Gets all KPI report.
        /// </summary>
        /// <param name="reportDate">The report date.</param>
        /// <returns>List of KPI report.</returns>
        [HttpGet]
        public IEnumerable<dynamic> ReportKPI(DateTime reportDate)
        {
            var data = _reportKPIService.GetReportKPI(reportDate);
            if (data != null && data.Any())
            {
                return data;
            }

            return new List<dynamic>();
        }

        /// <summary>
        /// Gets the specified report date.
        /// </summary>
        /// <param name="reportDate">The report date.</param>
        /// <returns>List of Top sport all.</returns>
        [HttpGet]
        public IEnumerable<dynamic> ReportTopSportAll(DateTime reportDate)
        {
            var data = _reportKPIService.GetTopSportAll(reportDate);
            if (data != null && data.Any())
            {
                return data;
            }

            return new List<dynamic>();
        }

        /// <summary>
        /// Reports the sun sport win loss.
        /// </summary>
        /// <param name="fromDate">The From date.</param>
        /// <param name="toDate">The To date.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="drawType">Type of the draw.</param>
        /// <param name="reportBy">The report by.</param>
        /// <returns>
        /// Sun Sport Win loss Exchange Model.
        /// </returns>
        [HttpGet]
        public dynamic ReportSunSportWinLoss(
            DateTime fromDate,
            DateTime toDate,
            int currency = 0,
            short drawType = 0,
            short reportBy = 0)
        {
            var data = _reportKPIService.GetReportSunSportWinLoss(fromDate, toDate, currency, drawType, reportBy);
            if (data != null)
            {
                return data;
            }

            return null;
        }

        /// <summary>
        /// Las the report sun sport win loss.
        /// </summary>
        /// <param name="fromDate">The From date.</param>
        /// <param name="toDate">The To date.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="drawType">Type of the draw.</param>
        /// <param name="reportBy">The report by.</param>
        /// <param name="baseCurrency">The base currency.</param>
        /// <returns>Sun Sport Win loss Exchange Model.</returns>
        [HttpGet]
        public IEnumerable<dynamic> LAReportSunSportWinLoss(
           DateTime fromDate,
           DateTime toDate,
           int currency = 0,
           short drawType = 0,
           short reportBy = 0,
            byte baseCurrency = 0)
        {
            var data = _reportKPIService.GetLAReportSunSportWinLoss(fromDate, toDate, currency, drawType, reportBy, baseCurrency);
            if (data != null && data.Any())
            {
                return data;
            }

            return new List<dynamic>();
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <returns>List of currency.</returns>
        public IEnumerable<dynamic> GetCurrency()
        {
            var data = _reportKPIService.GetCurrency();
            if (data != null && data.Any())
            {
                return data;
            }

            return new List<dynamic>();
        }
    }
}