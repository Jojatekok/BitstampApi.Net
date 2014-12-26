namespace Jojatekok.BitstampAPI.MarketTools
{
    public interface IConversionRate
    {
        float PriceBuy { get; }
        float PriceSell { get; }
    }
}
