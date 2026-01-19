public interface IBook
{
    public int? ID { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Category { get; set; }
    public int? Price { get; set; }
}

public class ILibrarySystem
{

}

public interface Book : IBook
{
    public int? ID { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Category { get; set; }
    public int? Price { get; set; }
}

public class LibrarySystem : ILibrarySystem
{
    private readonly Dictionary<IBook, int> _books = new Dictionary<IBook, int>();
    public void AddBook(IBook book, int quantity)
    {
        if (_books.ContainsKey(book))
        {
            _books[book] += quantity;
        }
        else
        {
            _books.Add(book, quantity);
        }

        Console.WriteLine("Book added/updated successfully!");
    }

    public void RemoveBook(IBook book, int quantity)
    {
        if (_books.ContainsKey(book))
        {
            Console.WriteLine("Book not found.");
            return;
        }

        _books[book] -= quantity;

        if (_books[book] <= 0)
        {
            _books.Remove(book);
            Console.WriteLine("Book removed completely!");
        }
        else
        {
            Console.WriteLine("Book quantity reduced!");
        }
    }


    public int CalculateTotal()
    {
        int Total = 0;
        foreach (var book in _books)
        {
            Total += book.Key.Price * book.Value;
        }

        return Total;
    }

    public List<(int Id, string Name, int Price)> CategoryTotalPrice()
    {
        
    }
}