using System.Reflection;

namespace Jojatekok.BitstampAPI.Demo
{
    public sealed partial class MainWindow
    {
        private BitstampClient BitstampClient { get; set; }

        public MainWindow()
        {
            // Set icon from the assembly
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location).ToImageSource();

            InitializeComponent();

            BitstampClient = new BitstampClient();
            LoadMarketSummaryAsync();
        }

        private async void LoadMarketSummaryAsync()
        {
            var market = await BitstampClient.Market.GetSummaryAsync();
            TextBlockPriceLast.Text = "$" + market.PriceLast.ToStringNormalized();
        }
    }
}
