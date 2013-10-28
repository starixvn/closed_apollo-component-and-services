using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apollo.ReportKPIService.Models
{
    public class KPIModel
    {
        public int? StatID { get; set; }

        public string StatName { get; set; }

        public double? CurrentDate { get; set; }

        public double? CurrentMonthMonthToDate { get; set; }

        public double? LastMonthMonthToDate { get; set; }

        public double? LastMonthFullMonth { get; set; }

        public double? FullYearToCurrentDateActual { get; set; }

        public double? FullYearToCurrentDateDailyAve { get; set; }

        public double? FullYearToLastMonthMonthlyAve { get; set; }

        public double? ThreeLastMonthsMonthlyAve { get; set; }

        public double? ThreeLastMonthsDailyAve { get; set; }
    }
}