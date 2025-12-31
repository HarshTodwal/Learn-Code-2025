using BookManagementApp.Entities;
using BookManagementApp.Services;

class Program
{
    static void Main()
    {
        var book = new Book("A Great Book", "John Doe");

        var printer = new PlainTextPrinter();
        printer.PrintPage($"Reading page {book.GetCurrentPage()}");

        book.TurnPage();

        var repository = new FileBookRepository();
        repository.Save(book);
    }
}
