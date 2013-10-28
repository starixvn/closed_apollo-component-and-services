// --------------------------------------------------------------------------
// <copyright file="QueryService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2013.10.28">Created</change>
// </history>
namespace Apollo.ReportKPIService.Services
{
    using System;
    using System.Collections.Generic;
    using Fanex.Common.Helper;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// This class encapsulate dynamic repository to provide.
    /// a flexible way to get data from database by using Stored Procedure.
    /// </summary>
    public class QueryService
    {
        private readonly IDynamicRepository _repository;

        public QueryService(IDynamicRepository repository = null)
        {
            _repository = repository ?? new DynamicRepository();
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <typeparam name="T">The Object.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Return list of objects.</returns>
        public virtual IEnumerable<T> GetData<T>(ICriteria criteria)
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            try
            {
                if (criteria.IsValid())
                {
                    return _repository.Fetch<T>(criteria);
                }

                return new List<T>();
            }
            catch (Exception ex)
            {
                Fanex.Logging.LogService.Error(ex.Message, ex);
                return null;
            }
        }
    }
}