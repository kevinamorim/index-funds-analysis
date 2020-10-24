using IndexFundsAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndexFundsAnalysis
{
    public class Simulator
    {
        private double _startingPrincipal;
        private double _monthlyAddition;
        private ICollection<Result> _historicalData;

        public Simulator(double startingPrincipal, 
            double monthlyAddition,
            ICollection<Result> historicalData)
        {
            _startingPrincipal = startingPrincipal;
            _monthlyAddition = monthlyAddition;
            _historicalData = historicalData;
        }

        public List<MonthReport> Run()
        {
            var result = new List<MonthReport>();

            var additionDay = 01;

            var startDate = new DateTime(2015, 10, additionDay);
            var endDate = new DateTime(2020, 10, additionDay);

            var currentDate = startDate;

            while(currentDate <= endDate)
            {
                //Console.WriteLine(currentDate);

                var data = _historicalData.SingleOrDefault(m => m.Date == currentDate);

                var currentMonth = currentDate.Month;
                var monthFound = true;

                while(data == null)
                {
                    currentDate = currentDate.AddDays(1);

                    if (currentDate.Month != currentMonth)
                    {
                        Console.WriteLine("MONTH NOT FOUND!");
                        currentDate = currentDate.AddDays(-1);
                        monthFound = false;
                        break;
                    }

                    data = _historicalData.SingleOrDefault(m => m.Date == currentDate);
                }

                if (!monthFound && result.Count <= 0)
                    continue;
                
                var purchasePrice = monthFound ? 
                    data.Close : 
                    result.ElementAt(result.Count - 1).PurchasePrice;

                if (purchasePrice == 0)
                    Console.WriteLine("We have a 0$ closing price!");

                var currentQty = result.Count > 0 ? result.ElementAt(result.Count - 1).Quantity : 0;
                var qtyPurchased = _monthlyAddition / purchasePrice;
                var newQty = currentQty + qtyPurchased;

                var currentValue = newQty * purchasePrice;
                
                var currentInvested = result.Count > 0 ? result.ElementAt(result.Count - 1).TotalInvested : 0;
                var newInvested = currentInvested + _monthlyAddition;

                if (currentDate.Year == 2020 && currentDate.Month == 10) newInvested -= 250;

                var roi = CalculatePercentageIncrease(newInvested, currentValue);

                result.Add(new MonthReport()
                {
                    Year = currentDate.Year,
                    Month = currentDate.Month,
                    Day = currentDate.Day,
                    PurchasePrice = purchasePrice,
                    Quantity = newQty,
                    CurrentValue = currentValue,
                    TotalInvested = newInvested,
                    ReturnOnInvestment = roi
                });

                currentDate = currentDate.AddMonths(1);
                currentDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            }

            return result;
        }

        private double CalculatePercentageIncrease(double start, double end)
        {
            return ((end - start) / Math.Abs(start)) * 100;
        }
    }
}
