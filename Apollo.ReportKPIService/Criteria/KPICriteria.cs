using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fanex.NAP.Framework.Data;

namespace Apollo.ReportKPIService.Criteria
{
    public class KPICriteria : CriteriaBase
    {
        public DateTime ReportDate { get; set; }

        public override string GetSettingKey()
        {
            return "OAS_Report_KPI";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}