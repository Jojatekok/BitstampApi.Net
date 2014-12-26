using System;

namespace Jojatekok.BitstampAPI.MarketTools
{
    public interface IMarketData
    {
        float PriceLast { get; }
        float PriceAverage24HourVolumeWeighted { get; }

        float Price24HourHigh { get; }
        float Price24HourLow { get; }

        double Volume24HourBase { get; }

        float OrderTopBuy { get; }
        float OrderTopSell { get; }
        float OrderSpreadValue { get; }
        float OrderSpreadPercentage { get; }

        DateTime ServerResponseTimestamp { get; }
    }
}
