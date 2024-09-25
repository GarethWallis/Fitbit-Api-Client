using Newtonsoft.Json;
using System;
using System.Globalization;

namespace FitbitApiClient.Models
{
    public class TimeSpanConverter : JsonConverter
    {
        private readonly string _format;

        // Default constructor with a default format
        public TimeSpanConverter()
        {
            _format = @"hh\:mm\:ss";  // Default format
        }

        // Constructor allowing for custom formats
        public TimeSpanConverter(string format)
        {
            _format = format;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;  // Handle null values gracefully
            }

            var timeString = serializer.Deserialize<string>(reader);
            if (string.IsNullOrEmpty(timeString))
            {
                return null;  // Handle empty string case
            }

            return TimeSpan.ParseExact(timeString!, _format, CultureInfo.InvariantCulture);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();  // Handle null TimeSpan values
                return;
            }

            var timespan = (TimeSpan)value;
            writer.WriteValue(timespan.ToString(_format));  // Use the defined format
        }
    }
}
