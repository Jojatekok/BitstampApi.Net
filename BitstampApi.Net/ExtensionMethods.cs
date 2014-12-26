using JackLeitch.RateGate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;

namespace Jojatekok.BitstampAPI
{
    public static class ExtensionMethods
    {
        private static readonly RateGate RateGate = new RateGate(600, TimeSpan.FromMinutes(10));

        internal static string GetResponseString(this HttpWebRequest request)
        {
            RateGate.WaitToProceed();
            using (var response = request.GetResponse()) {
                using (var stream = response.GetResponseStream()) {
                    if (stream == null) throw new NullReferenceException("The HttpWebRequest's response stream cannot be empty.");

                    using (var reader = new StreamReader(stream)) {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        internal static T DeserializeObject<T>(this JsonSerializer serializer, string value)
        {
            using (var stringReader = new StringReader(value)) {
                using (var jsonTextReader = new JsonTextReader(stringReader)) {
                    return (T)serializer.Deserialize(jsonTextReader, typeof(T));
                }
            }
        }

        internal static string ToHttpPostString(this Dictionary<string, object> dictionary)
        {
            var output = string.Empty;
            foreach (var entry in dictionary) {
                var valueString = entry.Value as string;
                if (valueString == null) {
                    output += "&" + entry.Key + "=" + entry.Value;
                } else {
                    output += "&" + entry.Key + "=" + valueString.Replace(' ', '+');
                }
            }

            return output.Substring(1);
        }

        internal static float RoundUp(this double value)
        {
            return (float)(Math.Ceiling(value * Utilities.FloatRoundingFractionToIntegerMultiplier) / Utilities.FloatRoundingFractionToIntegerMultiplier);
        }

        public static float Normalize(this float value)
        {
            return (float)Math.Round(value, Utilities.FloatRoundingPrecisionDigits, MidpointRounding.AwayFromZero);
        }

        public static string ToStringNormalized(this float value)
        {
            return value.ToString("0." + new string('0', Utilities.FloatRoundingPrecisionDigits), Utilities.InvariantCulture);
        }

        public static double Normalize(this double value)
        {
            return Math.Round(value, Utilities.DoubleRoundingPrecisionDigits, MidpointRounding.AwayFromZero);
        }

        public static string ToStringNormalized(this double value)
        {
            return value.ToString("0." + new string('0', Utilities.DoubleRoundingPrecisionDigits), Utilities.InvariantCulture);
        }

        public static string ToStringHex(this byte[] value)
        {
            var output = string.Empty;
            for (var i = 0; i < value.Length; i++) {
                output += value[i].ToString("x2", Utilities.InvariantCulture);
            }

            return (output);
        }
    }
}
