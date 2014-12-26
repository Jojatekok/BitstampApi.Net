namespace Jojatekok.BitstampAPI.MarketTools
{
    public class Order : IOrder
    {
        public float PricePerCoin { get; private set; }

        public double AmountBase { get; private set; }
        public float AmountQuote {
            get { return (AmountBase * PricePerCoin).RoundUp(); }
        }

        internal Order(float pricePerCoin, double amountBase)
        {
            PricePerCoin = pricePerCoin;
            AmountBase = amountBase;
        }

        internal Order()
        {

        }
    }
}
