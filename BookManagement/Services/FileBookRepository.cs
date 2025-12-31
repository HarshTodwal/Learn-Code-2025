using System.Text.Json;
using BookManagementApp.Entities;
using BookManagementApp.Interfaces;

namespace BookManagementApp.Services
{
    public class FileBookRepository : IBookRepository
    {
        public void Save(Book book)
        {
            string fileName = $"{book.Title} - {book.Author}.json";
            string content = JsonSerializer.Serialize(book);

            File.WriteAllText(fileName, content);
        }
    }
}
