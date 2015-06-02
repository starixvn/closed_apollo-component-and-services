// --------------------------------------------------------------------------
// <copyright file="ExchangeCodeCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Terry.Nguyen" date="2014.3.28">Created</change>
// </history>

namespace ExchangeRate.Criteria
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Exchange Code Criteria class.
    /// </summary>
    public class ExchangeCodeCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "Acc_ExchangeCodeSel";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
