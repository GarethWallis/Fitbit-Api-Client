using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FitbitApiClient.Models
{
    public class SpO2IntraData
    {
        [JsonProperty("dateTime")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateTime { get; set; }

        [JsonProperty("minutes")]
        public List<SpO2IntraValue>? Minutes { get; set; }
    }

    public class SpO2IntraValue
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("minute")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        public DateTime Minute { get; set; }
    }

}