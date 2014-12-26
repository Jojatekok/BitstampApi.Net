using Jojatekok.BitstampAPI.MarketTools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jojatekok.BitstampAPI
{
    public interface IMarket
    {
        /// <summary>Gets a data summary of the market.</summary>
        Task<IMarketData> GetSummaryAsync();

        /// <summary>Fetches every active order of the market.</summary>
        Task<IOrderBook> GetOpenOrdersAsync();

        /// <summary>Fetches the last trades of the market.</summary>
        /// <param name="timeInterval">The time interval to fetch data from.</param>
        Task<IList<ITrade>> GetTradesAsync(TimeInterval timeInterval = TimeInterval.Hour);

        /// <summary>Gets the current conversion rate of EUR/USD.</summary>
        Task<IConversionRate> GetConversionRateEurUsdAsync();
    }
}
