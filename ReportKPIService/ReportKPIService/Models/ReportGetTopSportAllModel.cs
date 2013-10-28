// --------------------------------------------------------------------------
// <copyright file="ReportGetTopSportAllModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.28">Created</change>
// </history>
namespace Apollo.ReportKPIService.Models
{
    /// <summary>
    /// KPI report get top sport all model.
    /// </summary>
    public class ReportGetTopSportAllModel
    {
        public int? StatId { get; set; }

        public string CurrentDate { get; set; }

        public string CurrentMonthMonthToDate { get; set; }

        public string LastMonthMonthToDate { get; set; }

        public string LastMonthFullMonth { get; set; }

        public string YearActual { get; set; }
    }
}