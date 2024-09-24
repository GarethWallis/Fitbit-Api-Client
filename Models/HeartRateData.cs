using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FitbitApiClient.Models
{
    public class HeartRateData
    {
        [JsonProperty("activities-heart")]
        public List<HeartActivity>? ActivitiesHeart { get; set; }

        [JsonProperty("activities-heart-intraday")]
        public HeartIntraday? ActivitiesHeartIntraday { get; set; }
    }

    public class HeartActivity
    {
        [JsonProperty("dateTime")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateTime { get; set; }

        [JsonProperty("value")]
        public HeartValue? Value { get; set; }
    }

    public class HeartValue
    {
        [JsonProperty("customHeartRateZones")]
        public List<HeartRateZone>? CustomHeartRateZones { get; set; }

        [JsonProperty("heartRateZones")]
        public List<HeartRateZone>? HeartRateZones { get; set; }

        [JsonProperty("restingHeartRate")]
        public int? RestingHeartRate { get; set; }
    }

    public class HeartRateZone
    {
        [JsonProperty("caloriesOut")]
        public double CaloriesOut { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("minutes")]
        public int Minutes { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class HeartIntraday
    {
        [JsonProperty("dataset")]
        public List<HeartDataPoint>? Dataset { get; set; }

        [JsonProperty("datasetInterval")]
        public int DatasetInterval { get; set; }

        [JsonProperty("datasetType")]
        public string? DatasetType { get; set; }
    }

    public class HeartDataPoint
    {
        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Time { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }

    public class TimeSpanConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null!;
            var value = serializer.Deserialize<string>(reader);
            return TimeSpan.Parse(value!);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            writer.WriteValue(((TimeSpan)value!).ToString(@"hh\:mm\:ss"));
        }
    }
}