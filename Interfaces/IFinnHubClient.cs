using CryptoExchange.Net.Objects;
using FinnHub.Net.Enums;
using FinnHub.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinnHub.Net.Interfaces
{
    public interface IFinnHubClient
    {
        #region Stock price
        /// <summary>
        /// Gets candles list by intrument and period
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="resolution">Supported resolution includes 1, 5, 15, 30, 60, D, W, M .Some timeframes might not be available depending on the exchange.</param>
        /// <param name="from">Interval initial value.</param>
        /// <param name="to">Interval end value.</param>
        /// <param name="adjusted">Use true to get adjusted data.</param>
        /// <returns></returns>
        Task<CallResult<List<Candle>>> GetCandlesAsync(string symbol, FinnHubTimeResolutions resolution, DateTime from, DateTime to, bool adjusted=false, CancellationToken ct=default);
        CallResult<List<Candle>> GetCandles(string symbol, FinnHubTimeResolutions resolution, DateTime from, DateTime to, bool adjusted = false);


        Task<CallResult<TickData>> GetTickDataAsync(string symbol, DateTime date, int limit, int skip, CancellationToken ct = default);
        CallResult<TickData> GetTickData(string symbol, DateTime date, int limit, int skip);


        #endregion
    }
}
