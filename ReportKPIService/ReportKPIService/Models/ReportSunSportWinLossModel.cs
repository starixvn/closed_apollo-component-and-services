// --------------------------------------------------------------------------
// <copyright file="ReportSunSportWinLossModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.28">Created</change>
// </history>
namespace Apollo.ReportKPIService.Models
{
    using System;

    /// <summary>
    /// Sun sport win lost model class.
    /// </summary>
    public class ReportSunSportWinLossModel
    {
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public DateTime RptDate { get; set; }

        public int TotalTrans { get; set; }

        public decimal? TurnOver { get; set; }

        public decimal? TurnOverEUR { get; set; }

        public decimal? WinLoss { get; set; }

        public double? WinLossEUR { get; set; }

        public decimal? WinLossCompany { get; set; }

        public double? WinLossCompanyEUR { get; set; }
    }
}