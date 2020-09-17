using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using System.Net.Http;

namespace FinnHub.Net
{
    public class FinnHubClientOptions : RestClientOptions
    {
        public FinnHubClientOptions(string key, string version = "v1") : base($"https://finnhub.io/api/{version}/")
        {
            ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials(key, key);
            LogVerbosity = CryptoExchange.Net.Logging.LogVerbosity.Debug;
            LogWriters = new System.Collections.Generic.List<System.IO.TextWriter>() { new DebugTextWriter() };
                
        }

        public FinnHubClientOptions(HttpClient httpClient, string version = "v1") : base(httpClient, $"https://finnhub.io/api/{version}/")
        {
        }
    }
}
