// --------------------------------------------------------------------------
// <copyright file="OAS_Report_SunSportWinLoss.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.24">Created</change>
// </history>

namespace Apollo.ReportKPIService.Criteria
{
    using System;
    using Fanex.NAP.Framework.Data;

    public class ReportSunSportWinLossCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Currency { get; set; }

        public short DrawType { get; set; }

        public short ReportBy { get; set; }

        public override string GetSettingKey()
        {
            return "OAS_Report_SunSportWinLoss";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
