// --------------------------------------------------------------------------
// <copyright file="GetCurrencyCriteria.cs" company="Nexcel Solutions Vietnam">
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

    public class GetCurrencyCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "OAS_SelCurrency";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}