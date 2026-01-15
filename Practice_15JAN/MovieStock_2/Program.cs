public class Movie
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public int Ratings { get; set; }

    public Movie(string title, string artist, string genre, int ratings)
    {
        Title = title;
        Artist = artist;
        Genre = genre;
        Ratings = ratings;
    }
}

public class Program
{
    public static List<Movie> MovieList = new List<Movie>();

    // CSV format: Title,Artist,Genre,Ratings
    public void AddMovie(string MovieDetails)
    {
        List<string> list = MovieDetails
            .Split(',')
            .Select(x => x.Trim())
            .ToList();

        MovieList.Add(new Movie(
            list[0],
            list[1],
            list[2],
            int.Parse(list[3])
        ));
    }

    // View movies by genre
    public List<Movie> ViewMoviesByGenre(string genre)
    {
        return MovieList
            .Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // View movies sorted by rating (descending)
    public List<Movie> ViewMoviesByRating()
    {
        return MovieList
            .OrderByDescending(m => m.Ratings)
            .ToList();
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter Number of Movies : ");
        int total = int.Parse(Console.ReadLine());

        for (int i = 0; i < total; i++)
        {
            Console.Write("Movie Name: ");
            string name = Console.ReadLine();

            Console.Write("Artist Name: ");
            string artist = Console.ReadLine();

            Console.Write("Movie Genre: ");
            string genre = Console.ReadLine();

            Console.Write("Movie Rating (0-10): ");
            int rating = int.Parse(Console.ReadLine());

            MovieList.Add(new Movie(name, artist, genre, rating));
            Console.WriteLine();
        }

        // demo usage
        Program p = new Program();

        Console.Write("\nEnter genre to search: ");
        string g = Console.ReadLine();

        var byGenre = p.ViewMoviesByGenre(g);
        foreach (var m in byGenre)
        {
            Console.WriteLine($"{m.Title} | {m.Artist} | {m.Genre} | {m.Ratings}");
        }

        Console.WriteLine("\nMovies sorted by rating:");
        foreach (var m in p.ViewMoviesByRating())
        {
            Console.WriteLine($"{m.Title} - {m.Ratings}");
        }
    }
}
