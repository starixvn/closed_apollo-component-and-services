// --------------------------------------------------------------------------
// <copyright file="ResultModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.4.2">Created</change>
// </history>

namespace ExchangeRate.Models
{
    /// <summary>
    /// Result Model class.
    /// </summary>
    public class ResultModel
    {
        public int ErrorCode { get; set; }

        public string ErrorMsg { get; set; }
    }
}