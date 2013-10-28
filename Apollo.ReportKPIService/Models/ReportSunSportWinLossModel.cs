using System;

namespace Apollo.ReportKPIService.Models
{
    public class ReportSunSportWinLossModel
    {
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public DateTime RptDate { get; set; }

        public int TotalTrans { get; set; }

        public decimal? TurnOver { get; set; }

        public decimal? WinLoss { get; set; }

        public double? WinLossEUR { get; set; }

        public decimal? WinLossCompany { get; set; }

        public double? WinLossCompanyEUR { get; set; }
    }
}