using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using FinnHub.Net.Enums;
using FinnHub.Net.Extensions;
using FinnHub.Net.Interfaces;
using FinnHub.Net.Objects;
using FinnHub.Net.Serializers;
using Newtonsoft.Json;
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
        private const string CandlesEndpoint = "stock/candle";

        private const string TickDataEndpoint = "stock/tick";

        #endregion
        public FinnHubClient(string key) : base(new FinnHubClientOptions(key), new FinnHubAuthenticationProvider(key))
        {
            
        }
        public FinnHubClient(FinnHubClientOptions exchangeOptions, FinnHubAuthenticationProvider authenticationProvider) : base(exchangeOptions, authenticationProvider)
        {
        }
        public CallResult<List<Candle>> GetCandles(string symbol, FinnHubTimeResolutions resolution, DateTime from, DateTime to, bool adjusted = false) => GetCandlesAsync(symbol,resolution,from,to,adjusted).Result;

        public async Task<CallResult<List<Candle>>> GetCandlesAsync(string symbol, FinnHubTimeResolutions resolution, DateTime from, DateTime to, bool adjusted = false, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(symbol), symbol);
            parameters.Add(nameof(resolution), JsonConvert.SerializeObject(resolution,new FinnHubTimeResolutionConverter(false)));
            parameters.Add(nameof(from), JsonConvert.SerializeObject(from, new TimestampSecondsConverter()));
            parameters.Add(nameof(to), JsonConvert.SerializeObject(to, new TimestampSecondsConverter()));
            parameters.Add(nameof(adjusted), adjusted);
            var result = await Get<CandlesResult>(parameters, CandlesEndpoint, ct);
            return new CallResult<List<Candle>>(result.Data?.ToCandlesList(), result.Error);
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
