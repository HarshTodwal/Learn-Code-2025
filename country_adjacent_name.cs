using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Dictionary mapping country codes to adjacent countries
        Dictionary<string, List<string>> adjacentCountries = new Dictionary<string, List<string>>()
        {
            { "IN", new List<string> { "Pakistan", "China", "Nepal", "Bhutan", "Bangladesh", "Myanmar", "Sri Lanka" } },
            { "US", new List<string> { "Canada", "Mexico" } },
            { "NZ", new List<string> { "Australia" } }
        };

        Console.Write("Enter Country Code (IN/US/NZ): ");
        string input = Console.ReadLine()?.ToUpper();

        if (adjacentCountries.ContainsKey(input))
        {
            Console.WriteLine("Adjacent Countries:");
            foreach (var country in adjacentCountries[input])
            {
                Console.WriteLine("- " + country);
            }
        }
        else
        {
            Console.WriteLine("Invalid or unsupported country code.");
        }

        Console.ReadLine();
    }
}
