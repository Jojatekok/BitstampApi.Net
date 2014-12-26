using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Jojatekok.BitstampAPI.MarketTools
{
    public class OrderBook : IOrderBook
    {
        [JsonProperty("bids")]
        private IList<string[]> BuyOrdersInternal {
            set { BuyOrders = ParseOrders(value); }
        }
        public IList<IOrder> BuyOrders { get; private set; }

        [JsonProperty("asks")]
        private IList<string[]> SellOrdersInternal {
            set { SellOrders = ParseOrders(value); }
        }
        public IList<IOrder> SellOrders { get; private set; }

        [JsonProperty("timestamp")]
        private ulong ServerResponseTimestampInternal {
            set { ServerResponseTimestamp = Utilities.UnixTimeStampToDateTime(value); }
        }
        public DateTime ServerResponseTimestamp { get; private set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IList<IOrder> ParseOrders(IList<string[]> orders)
        {
            var output = new List<IOrder>(orders.Count);
            for (var i = 0; i < orders.Count; i++) {
                var order = orders[i];
                output.Add(new Order(
                    float.Parse(order[0], Utilities.InvariantCulture),
                    double.Parse(order[1], Utilities.InvariantCulture)
                ));
            }
            return output;
        }
    }
}
