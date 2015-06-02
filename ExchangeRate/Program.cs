// --------------------------------------------------------------------------
// <copyright file="Program.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.4.1">Created</change>
// </history>

namespace ExchangeRate
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using ExchangeRate.Commons;
    using ExchangeRate.Criteria;
    using ExchangeRate.Models;
    using ExchangeRate.Services;
    using Fanex.Logging;

    /// <summary>
    /// Main program.
    /// </summary>
    internal class Program
    {
        private static ExchangeRateService service = new ExchangeRateService();
        private static CurrencyConvertor currencyConvertor = new CurrencyConvertor();

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]
        private static void Main(string[] args)
        {
            Fanex.Data.Configuration.DbSettingProviderManager.Current.Start();

            Stack<ExchangeCodeModel> currencies = null;
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now.AddDays(1);

            if (ApplicationSetting.IsUpdateOldData)
            {
                fromDate = ApplicationSetting.RateFromDate;
                toDate = ApplicationSetting.RateToDate;
                if (fromDate > toDate)
                {
                    return;
                }

                IEnumerable<ExchangeCodeModel> fromConfigCodes = service.GetExchangeFromConfigCode();
                IEnumerable<ExchangeCodeModel> exchangeCodes = service.GetExchangeCode();

                IEnumerable<DateTime> rateDates = EachDay(fromDate, toDate);

                foreach (var rateDate in rateDates)
                {
                    if (fromConfigCodes != null && fromConfigCodes.Any())
                    {
                        currencies = new Stack<ExchangeCodeModel>(fromConfigCodes);
                    }
                    else
                    {
                        currencies = new Stack<ExchangeCodeModel>(exchangeCodes);
                    }

                    Console.WriteLine("Application is starting...");
                    Console.WriteLine("- Rate Date: " + rateDate.ToShortDateString());

                    ExecCurrency(ref currencies, rateDate);
                }
            }
            else
            {
                currencies = new Stack<ExchangeCodeModel>(service.GetExchangeCode());

                Console.WriteLine("Application is starting...");
                Console.WriteLine("- Rate Date: " + DateTime.Now.ToShortDateString());

                ExecCurrency(ref currencies, DateTime.Now);

                UpdateActualRate();
                Console.WriteLine("Update actual rate successfully");
            }
        }

        /// <summary>
        /// Executes the currency.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        /// <param name="rateDate">The rate date.</param>
        private static void ExecCurrency(ref Stack<ExchangeCodeModel> currencies, DateTime rateDate)
        {
            try
            {
                if (currencies.Count() > 0)
                {
                    var currency = currencies.Pop();
                    var listExchangeRateCurrency = GetCurrencyValue(currency.CODE, rateDate);
                    var result = InsertCurrency(currency.CODE, listExchangeRateCurrency, rateDate);

                    if (result.ErrorCode == 0)
                    {
                        Console.WriteLine(currencies.Count() + ": Insert " + currency.CODE + " succesfully - Rate date: " + rateDate);

                        if (!ApplicationSetting.IsUpdateOldData)
                        {
                            result = InsertCurrency(currency.CODE, listExchangeRateCurrency, rateDate.AddDays(1));
                            if (result.ErrorCode == 0)
                            {
                                Console.WriteLine("- Insert " + currency.CODE + " succesfully - Rate date: " + rateDate.AddDays(1));
                            }
                        }

                        ExecCurrency(ref currencies, rateDate);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserts the currency.
        /// </summary>
        /// <param name="fromCurrency">From currency.</param>
        /// <param name="toCurrency">To currency.</param>
        /// <param name="rateDate">The rate date.</param>
        /// <returns>Result Model.</returns>
        private static ResultModel InsertCurrency(string fromCurrency, IEnumerable<ExchangeCurrencyRateModel> toCurrency, DateTime rateDate)
        {
            var criteria = new ExchangeDailyInsertCriteria();
            Hashtable parameters = new Hashtable();
            ResultModel result = new ResultModel();

            parameters.Add("code", fromCurrency);
            parameters.Add("errcode", 0);
            parameters.Add("errmsg", string.Empty);

            foreach (var item in toCurrency)
            {
                parameters.Add(item.Currency.ToLower(), item.CurrencyValue);
            }

            parameters.Add("rundate", rateDate);

            try
            {
                result = service.Update(criteria, parameters);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Updates the actual rate.
        /// </summary>
        /// <returns>Result Model.</returns>
        private static ResultModel UpdateActualRate()
        {
            var criteria = new ExchangeDailyActualRateUpdateCriteria();
            ResultModel result = new ResultModel();

            criteria.ErrCode = 0;
            criteria.ErrMsg = string.Empty;

            try
            {
                result = service.Update(criteria);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Gets the currency value.
        /// </summary>
        /// <param name="fromCurrency">From currency.</param>
        /// <param name="rateDate">The rate date.</param>
        /// <returns>Exchange Currency Rate Model.</returns>
        private static IEnumerable<ExchangeCurrencyRateModel> GetCurrencyValue(string fromCurrency, DateTime rateDate)
        {
            var fromCurrencies = ApplicationSetting.BaseCurrency.Split(',');
            var listExchangeRate = new List<ExchangeCurrencyRateModel>();

            if (fromCurrencies.Count() != 0)
            {
                foreach (var currency in fromCurrencies)
                {
                    var rate = currencyConvertor.GetExchangeRate(fromCurrency, currency, rateDate).Ask;

                    listExchangeRate.Add(
                        new ExchangeCurrencyRateModel
                        {
                            Currency = currency,
                            CurrencyValue = rate
                        });
                }
            }

            return listExchangeRate;
        }

        /// <summary>
        /// Each the day.
        /// </summary>
        /// <param name="fromDate">From the date.</param>
        /// <param name="toDate">To the date.</param>
        /// <returns>
        /// List of date.
        /// </returns>
        private static IEnumerable<DateTime> EachDay(DateTime fromDate, DateTime toDate)
        {
            for (var day = fromDate.Date; day.Date <= toDate.Date; day = day.AddDays(1))
            {
                yield return day;
            }
        }
    }
}