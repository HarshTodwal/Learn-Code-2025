using BookManagementApp.Interfaces;

namespace BookManagementApp.Services
{
    public class LibraryLocationService : ILocationService
    {
        public string GetLocation()
        {
            return "Room 2, Shelf A3";
        }
    }
}
