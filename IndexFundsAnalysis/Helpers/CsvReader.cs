using IndexFundsAnalysis.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace IndexFundsAnalysis.Helpers
{
    public class CsvReader
    {
        public List<Result> Read(string path, string filename)
        {
            List<Result> result = new List<Result>();

            using (var reader = new StreamReader(path + filename))
            {
                var firstLine = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (firstLine)
                    {
                        firstLine = !firstLine;
                        continue;
                    }

                    var values = line.Split(",");

                    var volume = -1.0;
                    double.TryParse(values[4], out volume);

                    result.Add(new Result()
                    {
                        Open = double.Parse(values[0]),
                        Close = double.Parse(values[1]),
                        High = double.Parse(values[2]),
                        Low = double.Parse(values[3]),
                        Volume = volume,
                        Date = DateTime.Parse(values[5])
                    });
                }
            }

            return result;
        }
    }
}