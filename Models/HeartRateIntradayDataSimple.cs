using Newtonsoft.Json;

namespace FitbitApiClient.Models
{
    public class HeartRateIntradayDataSimple
    {
        [JsonProperty("activities-heart")]
        public List<ActivityHeartSimple>? ActivitiesHeart { get; set; }

        [JsonProperty("activities-heart-intraday")]
        public ActivitiesHeartIntradaySimple? ActivitiesHeartIntraday { get; set; }
    }

    public class ActivityHeartSimple
    {
        [JsonProperty("dateTime")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateTime { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public class ActivitiesHeartIntradaySimple
    {
        [JsonProperty("dataset")]
        public List<HeartRateDataPointSimple>? Dataset { get; set; }

        [JsonProperty("datasetInterval")]
        public int DatasetInterval { get; set; }

        [JsonProperty("datasetType")]
        public string? DatasetType { get; set; }
    }

    public class HeartRateDataPointSimple
    {
        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanConverter), "hh\\:mm\\:ss")]
        public TimeSpan Time { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
