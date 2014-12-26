using System;
using System.Collections.Generic;

namespace Jojatekok.BitstampAPI.MarketTools
{
    public interface IOrderBook
    {
        IList<IOrder> BuyOrders { get; }
        IList<IOrder> SellOrders { get; }

        DateTime ServerResponseTimestamp { get; }
    }
}
