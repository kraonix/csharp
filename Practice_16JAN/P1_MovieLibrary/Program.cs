using System;
using System.Collections.Generic;
using System.Linq;

public interface IFilm
{
    string? Title { get; set; }
    string? Director { get; set; }
    int? Year { get; set; }
}

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    void GetFilms();
    void SearchFilms(string title);
    int GetTotalFilmCount();
}

public class Film : IFilm
{
    public string? Title { get; set; }
    public string? Director { get; set; }
    public int? Year { get; set; }
}

public class FilmLibrary : IFilmLibrary
{
    private readonly List<Film> _films = new List<Film>();

    public void AddFilm(IFilm film)
    {
        _films.Add((Film)film);
        Console.WriteLine("Film added successfully.");
    }

    public void RemoveFilm(string title)
    {
        var film = _films.FirstOrDefault(f =>
            f.Title != null &&
            f.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (film != null)
        {
            _films.Remove(film);
            Console.WriteLine("Film removed successfully.");
        }
        else
        {
            Console.WriteLine("Film not found.");
        }
    }

    public void GetFilms()
    {
        if (_films.Count == 0)
        {
            Console.WriteLine("No films available.");
            return;
        }

        Console.WriteLine("\nFilm List:");
        foreach (var film in _films)
        {
            Console.WriteLine($"- {film.Title} | {film.Director} | {film.Year}");
        }
    }

    public void SearchFilms(string title)
    {
        var results = _films.Where(f =>
            f.Title != null &&
            f.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("No matching films found.");
            return;
        }

        Console.WriteLine("\nSearch Results:");
        foreach (var film in results)
        {
            Console.WriteLine($"- {film.Title} | {film.Director} | {film.Year}");
        }
    }

    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IFilmLibrary library = new FilmLibrary();

        while (true)
        {
            Console.WriteLine("\nFilm Library Menu");
            Console.WriteLine("1. Add Film");
            Console.WriteLine("2. Remove Film");
            Console.WriteLine("3. View All Films");
            Console.WriteLine("4. Search Film");
            Console.WriteLine("5. Total Film Count");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    Console.Write("Title: ");
                    string title = Console.ReadLine()!;
                    Console.Write("Director: ");
                    string director = Console.ReadLine()!;
                    Console.Write("Year: ");
                    int year = int.Parse(Console.ReadLine()!);

                    library.AddFilm(new Film
                    {
                        Title = title,
                        Director = director,
                        Year = year
                    });
                    break;

                case 2:
                    Console.Write("Enter title to remove: ");
                    library.RemoveFilm(Console.ReadLine()!);
                    break;

                case 3:
                    library.GetFilms();
                    break;

                case 4:
                    Console.Write("Enter title to search: ");
                    library.SearchFilms(Console.ReadLine()!);
                    break;

                case 5:
                    Console.WriteLine($"Total Films: {library.GetTotalFilmCount()}");
                    break;

                case 0:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
