using System;
using System.Text.RegularExpressions;

namespace CoalitionBank.Common.Helpers
{
    public static class UUIDGenerator
    {
        public static string Generate(string prefix = null)
        {
            var uuid = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
            return !string.IsNullOrEmpty(prefix) ? $"{prefix}:{uuid}" : uuid;
        }
    }
}