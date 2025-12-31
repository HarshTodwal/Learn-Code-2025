using BookManagementApp.Entities;

namespace BookManagementApp.Interfaces
{
    public interface IBookRepository
    {
        void Save(Book book);
    }
}
