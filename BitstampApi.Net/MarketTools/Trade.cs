using Newtonsoft.Json;
using System;

namespace Jojatekok.BitstampAPI.MarketTools
{
    public class Trade : ITrade
    {
        [JsonProperty("date")]
        private ulong TimeInternal {
            set { Time = Utilities.UnixTimeStampToDateTime(value); }
        }
        public DateTime Time { get; private set; }

        [JsonProperty("price")]
        public float PricePerCoin { get; private set; }

        [JsonProperty("amount")]
        public double AmountBase { get; private set; }
        public float AmountQuote {
            get { return (AmountBase * PricePerCoin).RoundUp(); }
        }

        [JsonProperty("tid")]
        public ulong Id { get; private set; }
    }
}
