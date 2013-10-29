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
    using Apollo.ReportKPIService.Models;
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
        public IEnumerable<KPIModel> ReportKPI(DateTime reportDate)
        {
            var data = _reportKPIService.GetReportKPI(reportDate);
            if (data != null && data.Any())
            {
                return _reportKPIService.GetReportKPI(reportDate).ToList();
            }

            return new List<KPIModel>();
        }

        /// <summary>
        /// Gets the specified report date.
        /// </summary>
        /// <param name="reportDate">The report date.</param>
        /// <returns>List of Top sport all.</returns>
        [HttpGet]
        public IEnumerable<ReportGetTopSportAllModel> ReportTopSportAll(DateTime reportDate)
        {
            var data = _reportKPIService.GetTopSportAll(reportDate);
            if (data != null && data.Any())
            {
                return _reportKPIService.GetTopSportAll(reportDate).ToList();
            }

            return new List<ReportGetTopSportAllModel>();
        }

        /// <summary>
        /// Gets the specified from date.
        /// </summary>
        /// <param name="fromDate">Input from date.</param>
        /// <param name="toDate">Input to date.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="drawType">Type of the draw.</param>
        /// <param name="reportBy">The report by.</param>
        /// <returns>List of Sun win lost report.</returns>
        [HttpGet]
        public IEnumerable<ReportSunSportWinLossModel> ReportSunSportWinLoss(
            DateTime fromDate,
            DateTime toDate,
            int currency = 0,
            short drawType = 0,
            short reportBy = 0)
        {
            var data = _reportKPIService.GetReportSunSportWinLoss(fromDate, toDate, currency, drawType, reportBy);
            if (data != null && data.Any())
            {
                return data;
            }

            return new List<ReportSunSportWinLossModel>();
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <returns>List of currency.</returns>
        public IEnumerable<GetCurrencyModel> GetCurrency()
        {
            var data = _reportKPIService.GetCurrency();
            if (data != null && data.Any())
            {
                return data;
            }

            return new List<GetCurrencyModel>();
        }
    }
}