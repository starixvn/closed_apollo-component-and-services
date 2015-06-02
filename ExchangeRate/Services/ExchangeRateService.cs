// --------------------------------------------------------------------------
// <copyright file="ExchangeRateService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.4.2">Created</change>
// </history>

namespace ExchangeRate.Services
{
    using System.Collections;
    using System.Collections.Generic;
    using ExchangeRate.Commons;
    using ExchangeRate.Criteria;
    using ExchangeRate.Models;
    using Fanex.Data;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Exchange Rate Service.
    /// </summary>
    public class ExchangeRateService : QueryService
    {
        /// <summary>
        /// Gets the exchange code.
        /// </summary>
        /// <returns>List of exchange code.</returns>
        public IEnumerable<ExchangeCodeModel> GetExchangeCode()
        {
            IEnumerable<ExchangeCodeModel> models = null;
            models = GetData<ExchangeCodeModel>(new ExchangeCodeCriteria());

            return models;
        }

        /// <summary>
        /// Gets the exchange from configuration code.
        /// </summary>
        /// <returns>List of exchange code.</returns>
        public IEnumerable<ExchangeCodeModel> GetExchangeFromConfigCode()
        {
            List<ExchangeCodeModel> models = new List<ExchangeCodeModel>();
            string[] fromCurrencies = ApplicationSetting.FromCurrencies.Split(';');
            if (fromCurrencies.Length > 0)
            {
                foreach (var currency in fromCurrencies)
                {
                    models.Add(new ExchangeCodeModel { CODE = currency });
                }
            }

            return models;
        }

        /// <summary>
        /// Updates the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Result model.
        /// </returns>
        public ResultModel Update(ICriteria criteria, Hashtable parameters)
        {
            using (ObjectDb objDB = new ObjectDb(criteria.GetSettingKey()))
            {
                objDB.ExecuteNonQuery(parameters);

                return new ResultModel { ErrorCode = (int)parameters["errcode"], ErrorMsg = parameters["errmsg"].ToString() };
            }
        }

        /// <summary>
        /// Updates the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Result model.</returns>
        public ResultModel Update(ICriteria criteria)
        {
            using (ObjectDb objDB = new ObjectDb(criteria.GetSettingKey()))
            {
                var parameters = criteria.GetSpParams();
                objDB.ExecuteNonQuery(parameters);

                return new ResultModel { ErrorCode = (int)parameters["errcode"], ErrorMsg = parameters["errmsg"].ToString() };
            }
        }
    }
}