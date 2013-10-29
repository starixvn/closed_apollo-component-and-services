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
    using Apollo.ReportKPIService.Models;

    /// <summary>
    /// Report KPI Service Class.
    /// </summary>
    public class KPIService : QueryService
    {
        /// <summary>
        /// Gets the report KPI.
        /// </summary>
        /// <param name="reportDate">The report date.</param>
        /// <returns>List of Report KPI.</returns>
        public IEnumerable<KPIModel> GetReportKPI(DateTime reportDate)
        {
            IEnumerable<KPIModel> models = null;
            try
            {
                models = GetData<KPIModel>(new KPICriteria
                  {
                      ReportDate = reportDate
                  });
            }
            catch (Exception ex)
            {
                Fanex.Logging.LogService.Error(ex.Message, ex);
            }

            return models;
        }

        /// <summary>
        /// Gets the report sun sport win loss.
        /// </summary>
        /// <param name="fromDate">Input from date.</param>
        /// <param name="toDate">Input to date.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="drawType">Type of the draw.</param>
        /// <param name="reportBy">The report by.</param>
        /// <returns>
        /// List of report sun sport win lost.
        /// </returns>
        public IEnumerable<ReportSunSportWinLossModel> GetReportSunSportWinLoss(
            DateTime fromDate,
            DateTime toDate,
            int currency,
            short drawType,
            short reportBy)
        {
            IEnumerable<ReportSunSportWinLossModel> models = null;
            try
            {
                models = GetData<ReportSunSportWinLossModel>(new ReportSunSportWinLossCriteria
                {
                    FromDate = fromDate,
                    ToDate = toDate,
                    Currency = currency,
                    DrawType = drawType,
                    ReportBy = reportBy
                });
            }
            catch (Exception ex)
            {
                Fanex.Logging.LogService.Error(ex.Message, ex);
            }

            return models;
        }

        /// <summary>
        /// Gets the top sport all.
        /// </summary>
        /// <param name="reportDate">The report date.</param>
        /// <returns>List of top sport all.</returns>
        public IEnumerable<ReportGetTopSportAllModel> GetTopSportAll(DateTime reportDate)
        {
            IEnumerable<ReportGetTopSportAllModel> models = null;
            try
            {
                models = GetData<ReportGetTopSportAllModel>(new ReportGetTopSportAllCriteria
                {
                    ReportDate = reportDate
                });
            }
            catch (Exception ex)
            {
                Fanex.Logging.LogService.Error(ex.Message, ex);
            }

            return models;
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <returns>List of Currency.</returns>
        public IEnumerable<GetCurrencyModel> GetCurrency()
        {
            IEnumerable<GetCurrencyModel> models = null;
            try
            {
                models = GetData<GetCurrencyModel>(new GetCurrencyCriteria { });
            }
            catch (Exception ex)
            {
                Fanex.Logging.LogService.Error(ex.Message, ex);
            }

            return models;
        }
    }
}