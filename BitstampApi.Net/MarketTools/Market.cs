using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Jojatekok.BitstampAPI.MarketTools
{
    public class Market : IMarket
    {
        private ApiWebClient ApiWebClient { get; set; }

        internal Market(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
        }

        private IMarketData GetSummary()
        {
            return GetData<MarketData>("ticker");
        }

        private IOrderBook GetOpenOrders()
        {
            return GetData<OrderBook>("order_book");
        }

        private IList<ITrade> GetTrades(TimeInterval timeInterval)
        {
            var timeIntervalString = Enum.GetName(typeof(TimeInterval), timeInterval);
            Debug.Assert(timeIntervalString != null, "timeIntervalString != null");

            var data = GetData<IList<Trade>>(
                "transactions",
                "time=" + timeIntervalString.ToLower(Utilities.InvariantCulture)
            );
            return new List<ITrade>(data);
        }

        private IConversionRate GetConversionRateEurUsd()
        {
            return GetData<ConversionRate>("eur_usd");
        }

        public Task<IMarketData> GetSummaryAsync()
        {
            return Task.Factory.StartNew(() => GetSummary());
        }

        public Task<IOrderBook> GetOpenOrdersAsync()
        {
            return Task.Factory.StartNew(() => GetOpenOrders());
        }

        public Task<IList<ITrade>> GetTradesAsync(TimeInterval timeInterval)
        {
            return Task.Factory.StartNew(() => GetTrades(timeInterval));
        }

        public Task<IConversionRate> GetConversionRateEurUsdAsync()
        {
            return Task.Factory.StartNew(() => GetConversionRateEurUsd());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T GetData<T>(string command, params object[] parameters)
        {
            return ApiWebClient.GetData<T>(command, parameters);
        }
    }
}
