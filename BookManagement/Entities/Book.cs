namespace BookManagementApp.Entities
{
    public class Book
    {
        private int _currentPage = 1;

        public string Title { get; }
        public string Author { get; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public void TurnPage()
        {
            _currentPage++;
        }

        public int GetCurrentPage()
        {
            return _currentPage;
        }
    }
}
