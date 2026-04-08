using GeocodingApp.Models;

namespace GeocodingApp.Services
{
    public interface IGeocodingService
    {
        Task<LocationResult?> GetLocationAsync(string query);
    }
}