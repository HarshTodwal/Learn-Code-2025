using GeocodingApp.Config;
using GeocodingApp.Services;
using GeocodingApp.Utilities;

class Program
{
    static async Task Main()
    {
        var config = new AppConfig();
        IGeocodingService service = new NominatimGeocodingService(config);

        Console.Write("Enter location (city/country): ");
        string input = Console.ReadLine();

        if (!InputValidator.IsValid(input))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        try
        {
            var result = await service.GetLocationAsync(input);

            if (result == null)
            {
                Console.WriteLine("No results found.");
                return;
            }

            PrintResult(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void PrintResult(dynamic result)
    {
        Console.WriteLine("\nResult:\n");
        Console.WriteLine($"Location : {result.DisplayName}");
        Console.WriteLine($"Latitude : {result.Latitude}");
        Console.WriteLine($"Longitude: {result.Longitude}");
    }
}