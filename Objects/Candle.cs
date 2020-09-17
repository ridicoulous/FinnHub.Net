using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinnHub.Net.Objects
{
    public class CandlesResult
    {
        [JsonProperty("o")]
        public List<decimal> Opens { get; set; }
        [JsonProperty("h")]
        public List<decimal> Highs { get; set; }
        [JsonProperty("l")]
        public List<decimal> Lows { get; set; }
        [JsonProperty("c")]
        public List<decimal> Closes { get; set; }
        [JsonProperty("v")]
        public List<decimal> Volumes { get; set; }
        [JsonProperty("t")]
        public List<int> Timestamps { get; set; }
        [JsonProperty("s")]
        public string Status { get; set; }
    }

    public class Candle
    {
        public Candle(decimal open, decimal high, decimal low, decimal close, decimal volume, DateTime timestamp)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            Timestamp = timestamp;
        }

        public decimal Open { get; set; }       
        public decimal High { get; set; }      
        public decimal Low { get; set; }      
        public decimal Close { get; set; }     
        public decimal Volume { get; set; }       
        public DateTime Timestamp { get; set; }   
    }
  
}
