using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CTRLInvesting.Model.Stocks
{
    public class StockData
    {
        public Dictionary<string, double> Data { get; set; }
    }
}