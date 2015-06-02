// --------------------------------------------------------------------------
// <copyright file="ExchangeDailyInsertCriteria.cs" company="Nexcel Solutions Vietnam">
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
    /// Exchange Daily Insert Criteria Class.
    /// </summary>
    public class ExchangeDailyInsertCriteria : CriteriaBase
    {
        public string Code { get; set; }

        public double MYR { get; set; }

        public double USD { get; set; }

        public double EUR { get; set; }

        public double CNY { get; set; }

        public double IDR { get; set; }

        public double AUD { get; set; }

        public double CHF { get; set; }

        public double GBP { get; set; }

        public double SGD { get; set; }

        public double THB { get; set; }

        public double VND { get; set; }

        public double KRW { get; set; }

        public double JPY { get; set; }

        public DateTime RunDate { get; set; }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }

        public override string GetSettingKey()
        {
            return "Acc_ExchangeDailyIns";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}