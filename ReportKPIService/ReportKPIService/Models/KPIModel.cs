// --------------------------------------------------------------------------
// <copyright file="KPIModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.28">Created</change>
// </history>
namespace Apollo.ReportKPIService.Models
{
    /// <summary>
    /// KPI model class.
    /// </summary>
    public class KPIModel
    {
        public int? StatID { get; set; }

        public string StatName { get; set; }

        public double? CurrentDate { get; set; }

        public double? CurrentMonthMonthToDate { get; set; }

        public double? LastMonthMonthToDate { get; set; }

        public double? LastMonthFullMonth { get; set; }

        public double? FullYearToCurrentDateActual { get; set; }

        public double? FullYearToCurrentDateDailyAve { get; set; }

        public double? FullYearToLastMonthMonthlyAve { get; set; }

        public double? ThreeLastMonthsMonthlyAve { get; set; }

        public double? ThreeLastMonthsDailyAve { get; set; }
    }
}