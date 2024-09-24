using Newtonsoft.Json;

namespace FitbitApiClient.Models
{
    public class ActivityGoals
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
}
