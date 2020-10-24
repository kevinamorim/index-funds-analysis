using IndexFundsAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndexFundsAnalysis.Helpers
{
    public class Logger
    {
        public void PrintResults(ICollection<MonthReport> result, string title = "Untitled")
        {
            Console.WriteLine("==============================");
            Console.WriteLine(title);
            Console.WriteLine("==============================");
            Console.WriteLine("Investido ($): " + Math.Round(result.ElementAt(result.Count - 1).TotalInvested, 2));
            Console.WriteLine("Valor ($): " + Math.Round(result.ElementAt(result.Count - 1).CurrentValue, 2));
            Console.WriteLine("ROI (%): " + Math.Round(result.ElementAt(result.Count - 1).ReturnOnInvestment, 2));
            Console.WriteLine("==============================");
        }
    }
}
