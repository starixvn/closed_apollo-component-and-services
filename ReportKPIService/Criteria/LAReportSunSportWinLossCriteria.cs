// --------------------------------------------------------------------------
// <copyright file="LAReportSunSportWinLossCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.28">Created</change>
// </history>
namespace Apollo.ReportKPIService.Criteria
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Report sun sport win lost criteria class.
    /// </summary>
    public class LAReportSunSportWinLossCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Currency { get; set; }

        public short DrawType { get; set; }

        public short ReportBy { get; set; }

        public byte BaseCurrency { get; set; }

        public override string GetSettingKey()
        {
            return "LA_Report_SunSportWinLoss";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}