﻿namespace Jojatekok.BitstampAPI
{
    public interface IAuthenticator
    {
        /// <summary>Gets or sets the public API key to use Bitstamp's services with.</summary>
        string PublicKey { get; set; }

        /// <summary>Gets or sets the private API key to use Bitstamp's services with.</summary>
        string PrivateKey { get; set; }
    }
}
