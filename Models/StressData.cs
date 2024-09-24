using Newtonsoft.Json;

namespace FitbitApiClient.Models
{
    public class StressData
    {
        [JsonProperty("dateTime")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateTime { get; set; }

        [JsonProperty("value")]
        public StressValue? Value { get; set; }
    }

    public class StressValue
    {
        [JsonProperty("stressLevel")]
        public int StressLevel { get; set; }

        [JsonProperty("stressScore")]
        public int StressScore { get; set; }
    }
}
