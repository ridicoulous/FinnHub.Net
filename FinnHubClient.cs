using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using FinnHub.Net.Interfaces;
using FinnHub.Net.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FinnHub.Net
{
    public class FinnHubClient : RestClient, IFinnHubClient
    {
        #region Endpoints
        private const string TickDataEndpoint = "stock/tick";
        #endregion
        public FinnHubClient(string key) : base(new FinnHubClientOptions(key), new FinnHubAuthenticationProvider(key))
        {
        }
        public FinnHubClient(FinnHubClientOptions exchangeOptions, FinnHubAuthenticationProvider authenticationProvider) : base(exchangeOptions, authenticationProvider)
        {
        }


        public CallResult<TickData> GetTickData(string symbol, DateTime date, int limit, int skip) => GetTickDataAsync(symbol, date, limit, skip).Result;

        public async Task<CallResult<TickData>> GetTickDataAsync(string symbol, DateTime date, int limit, int skip, CancellationToken ct = default)
        {
            if (limit <= 0 || limit > 25000)
            {
                limit = 25000;
            }
            if (skip <= 0)
            {
                skip = 0;
            }
            var @params = new Dictionary<string, object>();
            @params.Add(nameof(symbol), symbol);
            @params.Add(nameof(date), date.ToString("yyyy-MM-dd"));
            @params.Add(nameof(limit), limit);
            @params.Add(nameof(skip), skip);
            @params.Add("format", "json");
            return await Get<TickData>(@params, TickDataEndpoint, ct);
        }

        private async Task<CallResult<TData>> Get<TData>(Dictionary<string, object> parameters, string endpoint, CancellationToken ct = default) where TData : class
        {
            return await SendRequest<TData>(GetUrl(endpoint), HttpMethod.Get, ct, parameters, true, false);
        }
        private Uri GetUrl(string endpoint)
        {
            return new Uri($"{BaseAddress}/{endpoint}");
        }

    }
}
