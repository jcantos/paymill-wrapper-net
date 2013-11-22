using System;
using System.Text.RegularExpressions;

namespace PaymillSharp.Internal
{
    internal static class EnumExtensions
    {
        public static string ToSnakeCase(this Enum val)
        {
            return Regex.Replace(val.ToString(), "([a-z])([A-Z])", "$1_$2").ToLowerInvariant();
        }
    }
}
