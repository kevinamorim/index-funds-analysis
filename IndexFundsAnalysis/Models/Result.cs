﻿using System;

namespace IndexFundsAnalysis.Models
{
    public class Result
    {
        public double Open { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double? Volume { get; set; }
        public DateTime Date { get; set; }
    }
}
