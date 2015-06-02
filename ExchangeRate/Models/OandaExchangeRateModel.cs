// --------------------------------------------------------------------------
// <copyright file="OandaExchangeRateModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.4.2">Created</change>
// </history>

namespace ExchangeRate.Models
{
    using System;

    /// <summary>
    /// OANDA Exchange Rate Model.
    /// </summary>
    public class OandaExchangeRateModel
    {
        public string Base { get; set; }

        public string Quote { get; set; }

        public int Amount { get; set; }

        public DateTime RateDate { get; set; }

        public double Ask { get; set; }

        public double Bid { get; set; }
    }
}