// --------------------------------------------------------------------------
// <copyright file="ExchangeDailyActualRateUpdateCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.3.31">Created</change>
// </history>

namespace ExchangeRate.Criteria
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Exchange daily actual rate updating criteria class.
    /// </summary>
    public class ExchangeDailyActualRateUpdateCriteria : CriteriaBase
    {
        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }

        public override string GetSettingKey()
        {
            return "Acc_ExchangeDaily_ActualRateUpd";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
