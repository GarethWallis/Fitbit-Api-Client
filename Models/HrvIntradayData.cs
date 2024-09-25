using FitbitApiClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitbitApiClient.Models
{
    public class HrvIntradayData
    {
        [JsonProperty("hrv")]
        public List<HrvData>? Hrv { get; set; }
    }

    public class HrvData
    {
        [JsonProperty("minutes")]
        public List<HrvMinuteData>? Minutes { get; set; }

        [JsonProperty("dateTime")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateTime { get; set; }
    }

    public class HrvMinuteData
    {
        [JsonProperty("minute")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss.fff")]
        public DateTime Minute { get; set; }

        [JsonProperty("value")]
        public HrvValue? Value { get; set; }
    }

    public class HrvValue
    {
        [JsonProperty("rmssd")]
        public double Rmssd { get; set; }

        [JsonProperty("coverage")]
        public double Coverage { get; set; }

        [JsonProperty("hf")]
        public double Hf { get; set; }

        [JsonProperty("lf")]
        public double Lf { get; set; }
    }

}
