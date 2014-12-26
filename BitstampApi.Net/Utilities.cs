using System;
using System.Globalization;
using System.Reflection;

namespace Jojatekok.BitstampAPI
{
    struct Utilities
    {
        public const string ApiUrlHttpsBase = "https://bitstamp.net/api/";

        public const int FloatRoundingPrecisionDigits = 2;
        public const int FloatRoundingFractionToIntegerMultiplier = 100;
        public const int DoubleRoundingPrecisionDigits = 8;

        public static readonly string AssemblyVersionString = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

        public static readonly DateTime DateTimeUnixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;

        public static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            return DateTimeUnixEpochStart.AddSeconds(unixTimeStamp);
        }

        public static ulong DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            return (ulong)Math.Floor(dateTime.Subtract(DateTimeUnixEpochStart).TotalSeconds);
        }
    }
}
