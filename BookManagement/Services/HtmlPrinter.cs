using BookManagementApp.Interfaces;

namespace BookManagementApp.Services
{
    public class HtmlPrinter : IPrinter
    {
        public void PrintPage(string pageContent)
        {
            Console.WriteLine($"<div class='single-page'>{pageContent}</div>");
        }
    }
}
