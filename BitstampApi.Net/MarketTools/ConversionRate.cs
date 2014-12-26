using Newtonsoft.Json;

namespace Jojatekok.BitstampAPI.MarketTools
{
    public class ConversionRate : IConversionRate
    {
        [JsonProperty("buy")]
        public float PriceBuy { get; private set; }

        [JsonProperty("sell")]
        public float PriceSell { get; private set; }
    }
}
