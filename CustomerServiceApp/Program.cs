using CustomerSearchApp.services;

class Program
{
    static void Main()
    {
        var searchService = new CustomerSearchService();

        var strategy = new CountrySearchStrategy("Germany");
        var customers = searchService.Search(strategy);

        var exporter = new CsvExportService();
        string csv = exporter.Export(customers);

        Console.WriteLine(csv);
    }
}
