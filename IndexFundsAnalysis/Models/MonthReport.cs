namespace IndexFundsAnalysis.Models
{
    public class MonthReport
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public double PurchasePrice { get; set; }
        public double Quantity { get; set; }
        public double CurrentValue { get; set; }
        public double TotalInvested { get; set; }
        public double ReturnOnInvestment { get; set; }
    }
}
