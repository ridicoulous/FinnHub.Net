using CryptoExchange.Net.Objects;
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
        Task<CallResult<TickData>> GetTickDataAsync(string symbol, DateTime date, int limit, int skip, CancellationToken ct = default);
        CallResult<TickData> GetTickData(string symbol, DateTime date, int limit, int skip);
        #endregion
    }
}
