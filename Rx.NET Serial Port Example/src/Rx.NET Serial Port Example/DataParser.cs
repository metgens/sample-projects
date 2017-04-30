using System.Globalization;
using System.Text.RegularExpressions;

namespace Rx.NET_Serial_Port_Example
{
    public class DataParser : IDataParser
    {
        /// <inheritdoc />
        public DeviceOutput Parse(string message)
        {
            var pattern = "^PREFIX ([0-9]+.[0-9]{2}) ([a-zA-z]*)$";
            var match = Regex.Match(message, pattern);

            if (match.Success)
            {
                var result = new DeviceOutput
                {
                    Value = float.Parse(match.Groups[1].Value.Trim(), CultureInfo.InvariantCulture),
                    Unit = match.Groups[2].Value.Trim().ToLower()
                };

                return result;
            }

            return null;
        }
    }

    public class DeviceOutput
    {
        public float? Value { get; set; }
        public string Unit { get; set; }
    }
}