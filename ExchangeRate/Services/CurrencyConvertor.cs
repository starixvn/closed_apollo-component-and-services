// --------------------------------------------------------------------------
// <copyright file="CurrencyConvertor.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.3.31">Created</change>
// </history>

namespace ExchangeRate.Services
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Net;
    using ExchangeRate.Commons;
    using ExchangeRate.Models;

    /// <summary>
    /// Currency Convertor class.
    /// </summary>
    public class CurrencyConvertor
    {
        /// <summary>
        /// Gets the exchange rate.
        /// </summary>
        /// <param name="fromCurrency">From currency.</param>
        /// <param name="toCurrency">To currency.</param>
        /// <param name="rateDate">The rate date.</param>
        /// <returns>
        /// OANDA exchange rate model.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]
        public OandaExchangeRateModel GetExchangeRate(string fromCurrency, string toCurrency, DateTime rateDate)
        {
            if (fromCurrency.Equals(toCurrency))
            {
                return new OandaExchangeRateModel
                {
                    Base = fromCurrency,
                    Quote = toCurrency,
                    Amount = 1,
                    RateDate =
                    rateDate,
                    Ask = 1.0,
                    Bid = 1.0
                };
            }

            string oandaUrl = string.Format(ApplicationSetting.OandaUrl, fromCurrency, toCurrency, rateDate.ToString("yyyy-MM-dd"), ApplicationSetting.APIKey);

            var exchangeRate = new OandaExchangeRateModel
            {
                Base = fromCurrency,
                Quote = toCurrency,
                Amount = 1,
                RateDate = rateDate,
                Ask = 0.0,
                Bid = 0.0
            };
            var request = (HttpWebRequest)WebRequest.Create(oandaUrl);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream());
                var responseString = reader.ReadToEnd();
                var lines = responseString.Split(new string[] { "\n" }, StringSplitOptions.None);

                if (lines.Length < 3)
                {
                    return exchangeRate;
                }

                var values = lines[1].Split(new string[] { "," }, StringSplitOptions.None);

                if (values.Length < 5)
                {
                    return exchangeRate;
                }

                return new OandaExchangeRateModel
                {
                    Base = values[0],
                    RateDate = string.IsNullOrWhiteSpace(values[2]) ? DateTime.Now : Convert.ToDateTime(values[2]),
                    Ask = string.IsNullOrWhiteSpace(values[4]) || values[4].ToLower() == "na" ? 0.0 : Convert.ToDouble(values[4]),
                    Bid = string.IsNullOrWhiteSpace(values[3]) || values[3].ToLower() == "na" ? 0.0 : Convert.ToDouble(values[3])
                };
            }

            return exchangeRate;
        }
    }
}