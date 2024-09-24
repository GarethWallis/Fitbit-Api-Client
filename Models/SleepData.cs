using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FitbitApiClient.Models
{
    public class SleepData
    {
        [JsonProperty("sleep")]
        public List<Sleep>? Sleep { get; set; }

        [JsonProperty("summary")]
        public SleepSummary? Summary { get; set; }
    }

    public class Sleep
    {
        [JsonProperty("dateOfSleep")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateOfSleep { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("efficiency")]
        public int Efficiency { get; set; }

        [JsonProperty("endTime")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime EndTime { get; set; }

        [JsonProperty("infoCode")]
        public int InfoCode { get; set; }

        [JsonProperty("isMainSleep")]
        public bool IsMainSleep { get; set; }

        [JsonProperty("levels")]
        public SleepLevels? Levels { get; set; }

        [JsonProperty("logId")]
        public long LogId { get; set; }

        [JsonProperty("minutesAfterWakeup")]
        public int MinutesAfterWakeup { get; set; }

        [JsonProperty("minutesAsleep")]
        public int MinutesAsleep { get; set; }

        [JsonProperty("minutesAwake")]
        public int MinutesAwake { get; set; }

        [JsonProperty("minutesToFallAsleep")]
        public int MinutesToFallAsleep { get; set; }

        [JsonProperty("startTime")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty("timeInBed")]
        public int TimeInBed { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }

    public class SleepLevels
    {
        [JsonProperty("summary")]
        public Dictionary<string, SleepLevelSummary>? Summary { get; set; }

        [JsonProperty("data")]
        public List<SleepLevelData>? Data { get; set; }

        [JsonProperty("shortData")]
        public List<SleepLevelData>? ShortData { get; set; }
    }

    public class SleepLevelSummary
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("minutes")]
        public int Minutes { get; set; }

        [JsonProperty("thirtyDayAvgMinutes")]
        public int ThirtyDayAvgMinutes { get; set; }
    }

    public class SleepLevelData
    {
        [JsonProperty("dateTime")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("level")]
        public string? Level { get; set; }

        [JsonProperty("seconds")]
        public int Seconds { get; set; }
    }

    public class SleepSummary
    {
        [JsonProperty("stages")]
        public Dictionary<string, int>? Stages { get; set; }

        [JsonProperty("totalMinutesAsleep")]
        public int TotalMinutesAsleep { get; set; }

        [JsonProperty("totalSleepRecords")]
        public int TotalSleepRecords { get; set; }

        [JsonProperty("totalTimeInBed")]
        public int TotalTimeInBed { get; set; }
    }
}