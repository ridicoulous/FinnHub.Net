using CryptoExchange.Net.Converters;
using FinnHub.Net.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinnHub.Net.Serializers
{
    public class FinnHubTimeResolutionConverter : BaseConverter<FinnHubTimeResolutions>
    {
        public FinnHubTimeResolutionConverter():base(true)
        {

        }
        public FinnHubTimeResolutionConverter(bool useQuotes) : base(useQuotes)
        {
        }

        protected override List<KeyValuePair<FinnHubTimeResolutions, string>> Mapping => new List<KeyValuePair<FinnHubTimeResolutions, string>>
        {
            new KeyValuePair<FinnHubTimeResolutions, string>(FinnHubTimeResolutions.Daily, "D"),
            new KeyValuePair<FinnHubTimeResolutions, string>(FinnHubTimeResolutions.Hourly, "60"),
            new KeyValuePair<FinnHubTimeResolutions, string>(FinnHubTimeResolutions.Monthly, "M"),
            new KeyValuePair<FinnHubTimeResolutions, string>(FinnHubTimeResolutions.Per15Minute, "15"),
            new KeyValuePair<FinnHubTimeResolutions, string>(FinnHubTimeResolutions.Per1Minute, "1"),
            new KeyValuePair<FinnHubTimeResolutions, string>(FinnHubTimeResolutions.Per30Minute, "30"),
            new KeyValuePair<FinnHubTimeResolutions, string>(FinnHubTimeResolutions.Per5Minute, "5"),
            new KeyValuePair<FinnHubTimeResolutions, string>(FinnHubTimeResolutions.Weekly, "w")
        };
    }
}
