using System;

namespace Jojatekok.BitstampAPI.MarketTools
{
    public interface ITrade
    {
        DateTime Time { get; }

        float PricePerCoin { get; }

        double AmountBase { get; }
        float AmountQuote { get; }

        ulong Id { get; }
    }
}
