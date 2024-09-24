using Newtonsoft.Json;

namespace FitbitApiClient.Models
{
    public class TemperatureData
    {
        [JsonProperty("dateTime")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateTime { get; set; }

        [JsonProperty("value")]
        public TemperatureValue? Value { get; set; }
    }

    public class TemperatureValue
    {
        [JsonProperty("nightlyRelative")]
        public double NightlyRelative { get; set; }
    }
}
