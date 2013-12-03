// --------------------------------------------------------------------------
// <copyright file="SunSportWinLossModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.30">Created</change>
// </history>
namespace ApolloReportKPIService.Models
{
    using System;

    /// <summary>
    /// Sun sport win loss model class.
    /// </summary>
    public class SunSportWinLossModel
    {
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public DateTime RptDate { get; set; }

        public int TotalTrans { get; set; }

        public decimal? TurnOver { get; set; }

        public double? TurnOverEUR { get; set; }

        public decimal? WinLoss { get; set; }

        public double? WinLossEUR { get; set; }

        public decimal? WinLossCompany { get; set; }

        public double? WinLossCompanyEUR { get; set; }

        public decimal? TCommission { get; set; }

        public double? TCommissionEUR { get; set; }

        public decimal? GrossWinLossCompany { get; set; }

        public double? GrossWinLossCompanyEUR { get; set; }
    }
}