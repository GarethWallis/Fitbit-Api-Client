using Newtonsoft.Json;

namespace FitbitApiClient.Models
{
    public class ActivitySummary
    {
        [JsonProperty("activities")]
        public List<Activity>? Activities { get; set; }

        [JsonProperty("goals")]
        public Goals? Goals { get; set; }

        [JsonProperty("summary")]
        public Summary? Summary { get; set; }
    }

    public class Activity
    {
        [JsonProperty("activityId")]
        public long ActivityId { get; set; }

        [JsonProperty("activityParentId")]
        public long ActivityParentId { get; set; }

        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("steps")]
        public int Steps { get; set; }
    }

    public class Goals
    {
        [JsonProperty("activeMinutes")]
        public int ActiveMinutes { get; set; }

        [JsonProperty("caloriesOut")]
        public int CaloriesOut { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("floors")]
        public int Floors { get; set; }

        [JsonProperty("steps")]
        public int Steps { get; set; }
    }

    public class Summary
    {
        [JsonProperty("activeScore")]
        public int ActiveScore { get; set; }

        [JsonProperty("activityCalories")]
        public int ActivityCalories { get; set; }

        [JsonProperty("caloriesBMR")]
        public int CaloriesBMR { get; set; }

        [JsonProperty("caloriesOut")]
        public int CaloriesOut { get; set; }

        [JsonProperty("distances")]
        public List<Distance>? Distances { get; set; }

        [JsonProperty("fairlyActiveMinutes")]
        public int FairlyActiveMinutes { get; set; }

        [JsonProperty("floors")]
        public int Floors { get; set; }

        [JsonProperty("lightlyActiveMinutes")]
        public int LightlyActiveMinutes { get; set; }

        [JsonProperty("marginalCalories")]
        public int MarginalCalories { get; set; }

        [JsonProperty("sedentaryMinutes")]
        public int SedentaryMinutes { get; set; }

        [JsonProperty("steps")]
        public int Steps { get; set; }

        [JsonProperty("veryActiveMinutes")]
        public int VeryActiveMinutes { get; set; }
    }

    public class Distance
    {
        [JsonProperty("activity")]
        public string? Activity { get; set; }

        [JsonProperty("distance")]
        public double DistanceValue { get; set; }
    }
}
