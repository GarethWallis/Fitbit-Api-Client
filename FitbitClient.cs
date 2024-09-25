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

        public async Task<List<ActivitySummary>> GetActivitySummaryByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetAsync<List<ActivitySummary>>($"activities/date/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}.json");
        }

        public async Task<HeartRateData> GetHeartRateAsync(DateTime date)
        {
            return await GetAsync<HeartRateData>($"activities/heart/date/{date:yyyy-MM-dd}/1d.json");
        }

        public async Task<HeartRateData> GetHeartRateByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetAsync<HeartRateData>($"activities/heart/date/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}.json");
        }
        public async Task<HeartRateIntradayData> GetHeartRateIntradayDataAsync(DateTime date, string detailLevel)
        {
            return await GetAsync<HeartRateIntradayData>($"activities/heart/date/{date:yyyy-MM-dd}/1d/{detailLevel}.json");
        }
        public async Task<HeartRateIntradayDataSimple> GetHeartRateIntradayDataWithTimeRangeAsync(DateTime date, string detailLevel, TimeSpan startTime, TimeSpan endTime)
        {
            return await GetAsync<HeartRateIntradayDataSimple>($"activities/heart/date/{date:yyyy-MM-dd}/1d/{detailLevel}/time/{startTime:hh\\:mm}/{endTime:hh\\:mm}.json");
        }

        public async Task<HrvIntradayData> GetHrvIntradayDataForSingleDayAsync(DateTime date)
        {
            return await GetAsync<HrvIntradayData>($"hrv/date/{date:yyyy-MM-dd}/all.json");
        }
        public async Task<HrvIntradayData> GetHrvIntradayDataForMultipleDaysAsync(DateTime startDate, DateTime endDate)
        {
            return await GetAsync<HrvIntradayData>($"hrv/date/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}/all.json");
        }

        public async Task<SleepData> GetSleepDataAsync(DateTime date)
        {
            return await GetAsync<SleepData>($"sleep/date/{date:yyyy-MM-dd}.json");
        }

        public async Task<SleepData> GetSleepDataByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetAsync<SleepData>($"sleep/date/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}.json");
        }

        public async Task<SpO2Data> GetSpO2DataAsync(DateTime date)
        {
            return await GetAsync<SpO2Data>($"spo2/date/{date:yyyy-MM-dd}.json");
        }

        public async Task<List<SpO2Data>> GetSpO2DataByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetAsync<List<SpO2Data>>($"spo2/date/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}.json");
        }

        public async Task<SpO2IntraData> GetSpO2IntraDataAsync(DateTime date)
        {
            return await GetAsync<SpO2IntraData>($"spo2/date/{date:yyyy-MM-dd}/all.json");
        }

        public async Task<List<SpO2IntraData>> GetSpO2IntraDataByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetAsync<List<SpO2IntraData>>($"spo2/date/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}/all.json");
        }

        public async Task<TemperatureData> GetTemperatureDataAsync(DateTime date)
        {
            return await GetAsync<TemperatureData>($"temp/core/date/{date:yyyy-MM-dd}.json");
        }

        public async Task<List<TemperatureData>> GetTemperatureDataByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetAsync<List<TemperatureData>>($"temp/core/date/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}.json");
        }

        public async Task<List<Exercise>> GetExercisesAsync(DateTime date)
        {
            return await GetAsync<List<Exercise>>($"activities/list.json?afterDate={date:yyyy-MM-dd}&sort=asc&offset=0&limit=100");
        }

        public async Task<List<Exercise>> GetExercisesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetAsync<List<Exercise>>($"activities/list.json?afterDate={startDate:yyyy-MM-dd}&beforeDate={endDate:yyyy-MM-dd}&sort=asc&offset=0&limit=100");
        }

        public async Task<ActivityGoals> GetActivityGoalsAsync()
        {
            return await GetAsync<ActivityGoals>("activities/goals/daily.json");
        }

        public async Task<T> GetAsync<T>(string endpoint)
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
            if (result != null)
            {
                return result;
            }
            throw new FitbitApiException($"Failed to deserialize response for endpoint: {endpoint}", content);
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
            : base(message) => RawContent = rawContent;
    }
}