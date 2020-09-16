using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FinnHub.Net
{
    public class FinnHubAuthenticationProvider : AuthenticationProvider
    {
        public FinnHubAuthenticationProvider(string key):base(new ApiCredentials(key,""))
        {

        }
        public FinnHubAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
        }
        public override Dictionary<string, string> AddAuthenticationToHeaders(string uri, HttpMethod method, Dictionary<string, object> parameters, bool signed, PostParameters postParameterPosition, ArrayParametersSerialization arraySerialization)
        {
            var result = new Dictionary<string, string>();
            result.Add("X-Finnhub-Token", Credentials.Key.GetString());
            return result;
        }
    }
}
