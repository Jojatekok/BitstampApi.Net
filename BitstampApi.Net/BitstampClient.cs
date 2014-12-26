using Jojatekok.BitstampAPI.MarketTools;

namespace Jojatekok.BitstampAPI
{
    public sealed class BitstampClient
    {
        ///// <summary>Represents the authenticator object of the client.</summary>
        //public IAuthenticator Authenticator { get; private set; }

        /// <summary>A class which contains market tools for the client.</summary>
        public IMarket Market { get; private set; }

        /// <summary>Creates a new instance of Bitstamp API .NET's client service.</summary>
        /// <param name="publicApiKey">Your public API key.</param>
        /// <param name="privateApiKey">Your private API key.</param>
        private BitstampClient(string publicApiKey, string privateApiKey)
        {
            var apiWebClient = new ApiWebClient(Utilities.ApiUrlHttpsBase);

            //Authenticator = new Authenticator(apiWebClient, publicApiKey, privateApiKey);

            Market = new Market(apiWebClient);
        }

        /// <summary>Creates a new, unauthorized instance of Bitstamp API .NET's client service.</summary>
        public BitstampClient() : this("", "")
        {

        }
    }
}
