using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class AdjacentCountryLookup
{
    static void Main()
    {
        const string dataFilePath = "adjacentCountryList.json";

        if (!File.Exists(dataFilePath))
        {
            Console.WriteLine("Adjacent country data file not found.");
            return;
        }

        string jsonData = File.ReadAllText(dataFilePath);

        Dictionary<string, List<string>> countryAdjacencyMap =
            JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonData);

        Console.Write("Enter country code (e.g., IN, US, NZ): ");
        string countryCodeInput = Console.ReadLine()?.Trim().ToUpper();

        if (countryAdjacencyMap != null &&
            countryAdjacencyMap.TryGetValue(countryCodeInput, out List<string> adjacentCountryList))
        {
            if (adjacentCountryList.Count == 0)
            {
                Console.WriteLine("This country has no adjacent countries (island nation).");
            }
            else
            {
                Console.WriteLine("Adjacent Countries:");
                foreach (string countryName in adjacentCountryList)
                {
                    Console.WriteLine($"- {countryName}");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid or unsupported country code.");
        }

        Console.ReadLine();
    }
}
