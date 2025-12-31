using BookManagementApp.Interfaces;

namespace BookManagementApp.Services
{
    public class PlainTextPrinter : IPrinter
    {
        public void PrintPage(string pageContent)
        {
            Console.WriteLine(pageContent);
        }
    }
}
