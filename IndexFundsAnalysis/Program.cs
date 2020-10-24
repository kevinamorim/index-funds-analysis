using IndexFundsAnalysis.Helpers;

namespace IndexFundsAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvReader = new CsvReader();

            var ftseHistoricalData = csvReader.Read(args[0], "ftse.csv");
            var sp500HistoricalData = csvReader.Read(args[0], "sp500.csv");

            var simFtse = new Simulator(0, 250, ftseHistoricalData);
            var simSp500 = new Simulator(0, 250, sp500HistoricalData);

            var ftseResults = simFtse.Run();
            var sp500Results = simSp500.Run();

            var logger = new Logger();

            logger.PrintResults(ftseResults, "FTSE All World");
            logger.PrintResults(sp500Results, "S&P 500");
        }
    }
}
