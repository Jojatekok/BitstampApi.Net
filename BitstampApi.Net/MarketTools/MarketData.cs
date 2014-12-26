using Newtonsoft.Json;
using System;

namespace Jojatekok.BitstampAPI.MarketTools
{
    public class MarketData : IMarketData
    {
        [JsonProperty("last")]
        public float PriceLast { get; internal set; }
        [JsonProperty("vwap")]
        public float PriceAverage24HourVolumeWeighted { get; internal set; }

        [JsonProperty("high")]
        public float Price24HourHigh { get; internal set; }
        [JsonProperty("low")]
        public float Price24HourLow { get; internal set; }

        [JsonProperty("volume")]
        public double Volume24HourBase { get; internal set; }

        [JsonProperty("bid")]
        public float OrderTopBuy { get; internal set; }
        [JsonProperty("ask")]
        public float OrderTopSell { get; internal set; }
        public float OrderSpreadValue {
            get { return (OrderTopSell - OrderTopBuy).Normalize(); }
        }
        public float OrderSpreadPercentage {
            get { return OrderTopSell / OrderTopBuy - 1; }
        }

        [JsonProperty("timestamp")]
        private ulong ServerResponseTimestampInternal {
            set { ServerResponseTimestamp = Utilities.UnixTimeStampToDateTime(value); }
        }
        public DateTime ServerResponseTimestamp { get; private set; }
    }
}
