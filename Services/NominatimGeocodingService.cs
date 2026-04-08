using GeocodingApp.Config;
using GeocodingApp.Models;
using System.Text.Json;

namespace GeocodingApp.Services
{
    public class NominatimGeocodingService : IGeocodingService
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfig _config;

        public NominatimGeocodingService(AppConfig config)
        {
            _config = config;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "MyApp/1.0");
        }

        public async Task<LocationResult?> GetLocationAsync(string query)
        {
            string url = BuildUrl(query);

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("API request failed");

            string json = await response.Content.ReadAsStringAsync();

            return ParseResponse(json);
        }

        private string BuildUrl(string query)
        {
            return $"{_config.BaseUrl}?q={query}&format=json&limit=1";
        }

        private LocationResult? ParseResponse(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (root.GetArrayLength() == 0)
                return null;

            var item = root[0];

            return new LocationResult
            {
                DisplayName = item.GetProperty("display_name").GetString(),
                Latitude = item.GetProperty("lat").GetString(),
                Longitude = item.GetProperty("lon").GetString()
            };
        }
    }
}