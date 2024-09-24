using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FitbitApiClient.Models
{
    public class Exercise
    {
        [JsonProperty("logId")]
        public long LogId { get; set; }

        [JsonProperty("activityName")]
        public string? ActivityName { get; set; }

        [JsonProperty("activityTypeId")]
        public int ActivityTypeId { get; set; }

        [JsonProperty("averageHeartRate")]
        public int AverageHeartRate { get; set; }

        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("distanceUnit")]
        public string? DistanceUnit { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("activeDuration")]
        public long ActiveDuration { get; set; }

        [JsonProperty("steps")]
        public int Steps { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }

        [JsonProperty("startTime")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty("originalStartTime")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime OriginalStartTime { get; set; }

        [JsonProperty("originalDuration")]
        public long OriginalDuration { get; set; }

        [JsonProperty("elevationGain")]
        public double ElevationGain { get; set; }

        [JsonProperty("hasActiveZoneMinutes")]
        public bool HasActiveZoneMinutes { get; set; }

        [JsonProperty("lastModified")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime LastModified { get; set; }
    }
}