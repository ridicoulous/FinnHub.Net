using FinnHub.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace FinnHub.Net.Extensions
{
    public static class MappingExtensions
    {
        public static List<Candle> ToCandlesList(this CandlesResult result)
        {
            if (result == null)
                return null;

            var resultsCount = result.Status == "ok" ? result.Closes.Count : 0;
            if (resultsCount == 0)
            {
                return new List<Candle>();
            }
            var mapping = new List<Candle>(resultsCount);
            var time = DateTime.UnixEpoch;
            for (int i = 0; i < result.Closes.Count; i++)
            {
                var candle = new Candle(
                    result.Opens[i],
                    result.Highs[i],
                    result.Lows[i],
                    result.Closes[i],
                    result.Volumes[i],
                    time.AddSeconds(result.Timestamps[i])
                    );

                mapping.Add(candle);
            }
            return mapping;
        }
    }
}
