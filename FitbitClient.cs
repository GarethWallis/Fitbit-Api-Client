using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FitbitApiClient.Models;

namespace FitbitApiClient
{
    public class FitbitClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.fitbit.com/1/user/-/";
        private bool _disposed = false;

        public FitbitClient(string accessToken)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        }

        public async Task<UserProfile> GetProfileAsync()
        {
            return await GetAsync<UserProfile>("profile.json");
        }

        public async Task<ActivitySummary> GetActivitySummaryAsync(DateTime date)
        {
            return await GetAsync<ActivitySummary>($"activities/date/{date:yyyy-MM-dd}.json");
        }

        public async Task<HeartRateData> GetHeartRateAsync(DateTime date)
        {
            return await GetAsync<HeartRateData>($"activities/heart/date/{date:yyyy-MM-dd}/1d.json");
        }

        public async Task<SleepData> GetSleepDataAsync(DateTime date)
        {
            return await GetAsync<SleepData>($"sleep/date/{date:yyyy-MM-dd}.json");
        }

        public async Task<SpO2Data> GetSpO2DataAsync(DateTime date)
        {
            return await GetAsync<SpO2Data>($"spo2/date/{date:yyyy-MM-dd}.json");
        }

        public async Task<TemperatureData> GetTemperatureDataAsync(DateTime date)
        {
            return await GetAsync<TemperatureData>($"temp/core/date/{date:yyyy-MM-dd}.json");
        }

        public async Task<StressData> GetStressDataAsync(DateTime date)
        {
            return await GetAsync<StressData>($"stress/date/{date:yyyy-MM-dd}.json");
        }

        public async Task<List<Exercise>> GetExercisesAsync(DateTime date)
        {
            return await GetAsync<List<Exercise>>($"activities/list.json?afterDate={date:yyyy-MM-dd}&sort=asc&offset=0&limit=100");
        }

        public async Task<ActivityGoals> GetActivityGoalsAsync()
        {
            return await GetAsync<ActivityGoals>("activities/goals/daily.json");
        }

        private async Task<T> GetAsync<T>(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            T? result = JsonConvert.DeserializeObject<T>(content, settings);
            if (result == null)
            {
                throw new FitbitApiException($"Failed to deserialize response for endpoint: {endpoint}", content);
            }
            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                }
                _disposed = true;
            }
        }
    }

    public class FitbitApiException : Exception
    {
        public string RawContent { get; }

        public FitbitApiException(string message, string rawContent)
            : base(message)
        {
            RawContent = rawContent;
        }
    }
}