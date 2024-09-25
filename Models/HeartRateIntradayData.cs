using Newtonsoft.Json;

namespace FitbitApiClient.Models
{
    public class HeartRateIntradayData
    {
        [JsonProperty("activities-heart")]
        public List<ActivityHeart>? ActivitiesHeart { get; set; }

        [JsonProperty("activities-heart-intraday")]
        public ActivitiesHeartIntraday? ActivitiesHeartIntraday { get; set; }
    }

    public class ActivityHeart
    {
        [JsonProperty("dateTime")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateTime { get; set; }

        [JsonProperty("value")]
        public HeartRateValue? Value { get; set; }
    }

    public class HeartRateValue
    {
        [JsonProperty("customHeartRateZones")]
        public List<HeartRateZone>? CustomHeartRateZones { get; set; }

        [JsonProperty("heartRateZones")]
        public List<HeartRateZone>? HeartRateZones { get; set; }

        [JsonProperty("restingHeartRate")]
        public int RestingHeartRate { get; set; }
    }

    public class ActivitiesHeartIntraday
    {
        [JsonProperty("dataset")]
        public List<HeartRateDataPoint>? Dataset { get; set; }

        [JsonProperty("datasetInterval")]
        public int DatasetInterval { get; set; }

        [JsonProperty("datasetType")]
        public string? DatasetType { get; set; }
    }

    public class HeartRateDataPoint
    {
        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanConverter))]  // No format in the attribute, the default will be used
        public TimeSpan Time { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }

}