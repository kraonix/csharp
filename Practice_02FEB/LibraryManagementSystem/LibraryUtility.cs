namespace LMS
{

    public class LibraryUtility
    {
        private List<Book> books = new List<Book>();
        private int idCounter = 1;   // auto increment id

        // Add book
        public void AddBook(string title, string author, string genre, int year)
        {
            Book book = new Book()
            {
                Id = idCounter++,
                Title = title,
                Author = author,
                Genre = genre,
                PublicationYear = year
            };

            books.Add(book);
        }

        // Group books by genre alphabetically
        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string, List<Book>> result = new SortedDictionary<string, List<Book>>();

            foreach (var book in books)
            {
                if (!result.ContainsKey(book.Genre))
                    result[book.Genre] = new List<Book>();

                result[book.Genre].Add(book);
            }

            return result;
        }

        // Search books by author
        public List<Book> GetBooksByAuthor(string author)
        {
            return books
                .Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Total books
        public int GetTotalBooksCount()
        {
            return books.Count;
        }
    }

}