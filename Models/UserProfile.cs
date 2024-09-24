using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FitbitApiClient.Models
{
    public class UserProfile
    {
        [JsonProperty("user")]
        public User? User { get; set; }
    }

    public class User
    {
        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("avatar")]
        public string? Avatar { get; set; }

        [JsonProperty("dateOfBirth")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("gender")]
        public string? Gender { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("memberSince")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime MemberSince { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }

    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}