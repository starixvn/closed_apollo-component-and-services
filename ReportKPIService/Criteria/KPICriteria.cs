// --------------------------------------------------------------------------
// <copyright file="KPICriteria.cs" company="Nexcel Solutions Vietnam">
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
    /// KPI criteria class.
    /// </summary>
    public class KPICriteria : CriteriaBase
    {
        public DateTime ReportDate { get; set; }

        /// <summary>
        /// Gets the setting key.
        /// </summary>
        /// <returns>Store name.</returns>
        public override string GetSettingKey()
        {
            return "OAS_Report_KPI";
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