// --------------------------------------------------------------------------
// <copyright file="ApplicationSetting.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.3.31">Created</change>
// </history>

namespace ExchangeRate.Commons
{
    using System;
    using System.Configuration;
    using Fanex.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class ApplicationSetting
    {
        /// <summary>
        /// Gets the OANDA URL.
        /// </summary>
        /// <value>
        /// The OANDA URL.
        /// </value>
        public static string OandaUrl
        {
            get
            {
                return GetValue("OandaUrl").ToString();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is update old data.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is update old data; otherwise, <c>false</c>.
        /// </value>
        public static bool IsUpdateOldData
        {
            get
            {
                return GetValue("UpdateOldData").ToString() == "1";
            }
        }

        /// <summary>
        /// Gets the rate from date.
        /// </summary>
        /// <value>
        /// The rate from date.
        /// </value>
        public static DateTime RateFromDate
        {
            get
            {
                return Convert.ToDateTime(GetValue("RateDateFrom"));
            }
        }

        /// <summary>
        /// Gets the rate to date.
        /// </summary>
        /// <value>
        /// The rate to date.
        /// </value>
        public static DateTime RateToDate
        {
            get
            {
                return Convert.ToDateTime(GetValue("RateDateTo"));
            }
        }

        /// <summary>
        /// Gets the base currency.
        /// </summary>
        /// <value>
        /// The base currency.
        /// </value>
        public static string BaseCurrency
        {
            get
            {
                return GetValue("BaseCurrencies").ToString();
            }
        }

        /// <summary>
        /// Gets from currencies.
        /// </summary>
        /// <value>
        /// From currencies.
        /// </value>
        public static string FromCurrencies
        {
            get
            {
                return GetValue("FromCurrencies").ToString();
            }
        }

        public static bool IsEncryptionKey
        {
            get
            {
                return !IsUpdateOldData;
            }
        }

        public static string APIKey
        {
            get
            {
                var key = GetValue("OandaAPIKey").ToString();
                if (IsEncryptionKey)
                {
                    key = Cryptography.CfsDeCrypt(key);
                }

                return key;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The setting key.</param>
        /// <returns>Value object.</returns>
        private static object GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}