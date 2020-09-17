using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinnHub.Net.Objects
{
    public class TickData
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; }
        /// <summary>
        /// Number of ticks skipped.
        /// </summary>
        [JsonProperty("skip")]
        public int Skip { get; set; }
        /// <summary>
        /// Number of ticks returned. If count < limit, all data for that date has been returned.
        /// </summary>
        [JsonProperty("count")]
        public int ResultsCount { get; set; }
        /// <summary>
        /// Total number of ticks for that date.
        /// </summary>
        [JsonProperty("total")]
        public int TotalCount { get; set; }
        /// <summary>
        /// List of volume data.
        /// </summary>
        [JsonProperty("v")]
        public List<decimal> Volumes { get; set; }
        /// <summary>
        /// List of price data.
        /// </summary>
        [JsonProperty("p")]
        public List<decimal> Prices { get; set; }
        /// <summary>
        /// List of timestamp in UNIX ms.
        /// </summary>
        [JsonProperty("t")]
        public List<decimal> Times { get; set; }
        /// <summary>
        /// List of venues/exchanges.
        /// </summary>
        [JsonProperty("x")]
        public List<string> Exchanges { get; set; }
    }


}
