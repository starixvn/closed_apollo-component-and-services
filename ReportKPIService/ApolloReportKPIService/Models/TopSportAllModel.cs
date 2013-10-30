// --------------------------------------------------------------------------
// <copyright file="TopSportAllModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.30">Created</change>
// </history>
namespace ApolloReportKPIService.Models
{
    /// <summary>
    /// Top sport all model class.
    /// </summary>
    public class TopSportAllModel
    {
        public int? StatId { get; set; }

        public string CurrentDate { get; set; }

        public string CurrentMonthMonthToDate { get; set; }

        public string LastMonthMonthToDate { get; set; }

        public string LastMonthFullMonth { get; set; }

        public string YearActual { get; set; }
    }
}