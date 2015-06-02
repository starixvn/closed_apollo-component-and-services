// --------------------------------------------------------------------------
// <copyright file="ReportSunSportWinLossCriteria.cs" company="Nexcel Solutions Vietnam">
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
    public class ReportSunSportWinLossCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Currency { get; set; }

        public short DrawType { get; set; }

        public short ReportBy { get; set; }

        /// <summary>
        /// Gets the setting key.
        /// </summary>
        /// <returns>Store name.</returns>
        public override string GetSettingKey()
        {
            return "OAS_Report_SunSportWinLoss";
        }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>Return true if anything is valid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}