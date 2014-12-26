namespace Jojatekok.BitstampAPI.MarketTools
{
    public interface IOrder
    {
        float PricePerCoin { get; }

        double AmountBase { get; }
        float AmountQuote { get; }
    }
}
