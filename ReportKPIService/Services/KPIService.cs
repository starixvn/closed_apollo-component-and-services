// --------------------------------------------------------------------------
// <copyright file="KPIService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.24">Created</change>
// </history>
namespace Apollo.ReportKPIService.Services
{
    using System;
    using System.Collections.Generic;
    using Apollo.ReportKPIService.Criteria;

    using Apollo.ReportKPIService.Repositories;

    /// <summary>
    /// Report KPI Service Class.
    /// </summary>
    public class KPIService : QueryService
    {
        private readonly ReportSunSportWinlossRepository _reportSunSportWinlossRepository;

        public KPIService()
        {
            _reportSunSportWinlossRepository = new ReportSunSportWinlossRepository();
        }

        /// <summary>
        /// Gets the report KPI.
        /// </summary>
        /// <param name="reportDate">The report date.</param>
        /// <returns>List of Report KPI.</returns>
        public IEnumerable<dynamic> GetReportKPI(DateTime reportDate)
        {
            IEnumerable<dynamic> models = null;

            models = GetData<dynamic>(new KPICriteria
            {
                ReportDate = reportDate
            });

            return models;
        }

        /// <summary>
        /// Gets the report sun sport win loss.
        /// </summary>
        /// <param name="fromDate">The From date.</param>
        /// <param name="toDate">The To date.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="drawType">Type of the draw.</param>
        /// <param name="reportBy">The report by.</param>
        /// <returns>
        /// Sun Sport Win loss Exchange Model.
        /// </returns>
        public dynamic GetReportSunSportWinLoss(
            DateTime fromDate,
            DateTime toDate,
            int currency,
            short drawType,
            short reportBy)
        {
            dynamic model = _reportSunSportWinlossRepository.Get(new ReportSunSportWinLossCriteria
                {
                    FromDate = fromDate,
                    ToDate = toDate,
                    Currency = currency,
                    DrawType = drawType,
                    ReportBy = reportBy
                });

            return model;
        }

        /// <summary>
        /// Gets the top sport all.
        /// </summary>
        /// <param name="reportDate">The report date.</param>
        /// <returns>List of top sport all.</returns>
        public IEnumerable<dynamic> GetTopSportAll(DateTime reportDate)
        {
            IEnumerable<dynamic> models = null;

            models = GetData<dynamic>(new ReportGetTopSportAllCriteria
            {
                ReportDate = reportDate
            });

            return models;
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <returns>List of Currency.</returns>
        public IEnumerable<dynamic> GetCurrency()
        {
            IEnumerable<dynamic> models = null;

            models = GetData<dynamic>(new GetCurrencyCriteria { });

            return models;
        }

        /// <summary>
        /// Gets the la report sun sport win loss.
        /// </summary>
        /// <param name="fromDate">The From date.</param>
        /// <param name="toDate">The To date.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="drawType">Type of the draw.</param>
        /// <param name="reportBy">The report by.</param>
        /// <param name="baseCurrency">The base currency.</param>
        /// <returns>List of sun sport win loss.</returns>
        public IEnumerable<dynamic> GetLAReportSunSportWinLoss(
            DateTime fromDate,
            DateTime toDate,
            int currency,
            short drawType,
            short reportBy,
            byte baseCurrency)
        {
            IEnumerable<dynamic> models = null;

            models = GetData<dynamic>(new LAReportSunSportWinLossCriteria
            {
                FromDate = fromDate,
                ToDate = toDate,
                Currency = currency,
                DrawType = drawType,
                ReportBy = reportBy,
                BaseCurrency = baseCurrency
            });

            return models;
        }
    }
}