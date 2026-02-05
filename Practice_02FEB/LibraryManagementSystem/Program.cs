namespace LMS
{
    class Program
    {
        static void Main()
        {
            LibraryUtility library = new LibraryUtility();

            // 1. Add books
            library.AddBook("The Hobbit", "J.R.R. Tolkien", "Fiction", 1937);
            library.AddBook("Clean Code", "Robert Martin", "Non-Fiction", 2008);
            library.AddBook("Sherlock Holmes", "Arthur Conan Doyle", "Mystery", 1892);
            library.AddBook("The Two Towers", "J.R.R. Tolkien", "Fiction", 1954);

            // 2. Display books grouped by genre
            Console.WriteLine("\n--- Books Grouped by Genre ---");
            var grouped = library.GroupBooksByGenre();

            foreach (var genre in grouped)
            {
                Console.WriteLine("\n" + genre.Key + ":");
                foreach (var book in genre.Value)
                {
                    Console.WriteLine($"  {book.Title} by {book.Author}");
                }
            }

            // 3. Search by Author
            Console.WriteLine("\n--- Books by J.R.R. Tolkien ---");
            var authorBooks = library.GetBooksByAuthor("J.R.R. Tolkien");

            foreach (var book in authorBooks)
            {
                Console.WriteLine($"{book.Title} ({book.Genre})");
            }

            // 4. Statistics
            Console.WriteLine("\n--- Statistics ---");
            Console.WriteLine("Total Books: " + library.GetTotalBooksCount());

            foreach (var genre in grouped)
            {
                Console.WriteLine($"{genre.Key}: {genre.Value.Count} books");
            }
        }
    }

}