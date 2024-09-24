using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FitbitApiClient.Models
{
    public class SpO2Data
    {
        [JsonProperty("dateTime")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateTime { get; set; }

        [JsonProperty("value")]
        public SpO2Value? Value { get; set; }
    }

    public class SpO2Value
    {
        [JsonProperty("avg")]
        public double? Average { get; set; }

        [JsonProperty("min")]
        public double? Minimum { get; set; }

        [JsonProperty("max")]
        public double? Maximum { get; set; }
    }
}