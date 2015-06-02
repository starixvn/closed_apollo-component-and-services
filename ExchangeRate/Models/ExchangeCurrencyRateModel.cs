// --------------------------------------------------------------------------
// <copyright file="ExchangeCurrencyRateModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.4.2">Created</change>
// </history>

namespace ExchangeRate.Models
{
    /// <summary>
    /// Exchange Currency Rate Model.
    /// </summary>
    public class ExchangeCurrencyRateModel
    {
        public string Currency { get; set; }

        public double CurrencyValue { get; set; }
    }
}