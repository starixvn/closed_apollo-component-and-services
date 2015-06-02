// --------------------------------------------------------------------------
// <copyright file="ReportSunSportWinlossRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.1.8">Created</change>
// </history>
namespace Apollo.ReportKPIService.Repositories
{
    using Fanex.Data;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Report Sun Sport Win loss Repository class.
    /// </summary>
    public class ReportSunSportWinlossRepository : ReadonlyRepository<dynamic>
    {
        /// <summary>
        /// Gets the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Sun Sport Win loss Exchange Model.</returns>
        public override dynamic Get(ICriteria criteria)
        {
            dynamic model = null;

            using (IObjectDb db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var multi = db.QueryMultiple(criteria.GetSpParams()))
                {
                    model = new
                    {
                        SunSportWinLoss = multi.Read<dynamic>(),
                        Exchange = multi.Read<dynamic>()
                    };
                }
            }

            return model;
        }
    }
}