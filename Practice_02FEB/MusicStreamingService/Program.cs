using System;

class Program
{
    static void Main()
    {
        MusicManager manager = new MusicManager();

        // ---------- Hardcoded Initial Data ----------
        manager.AddSong("Shape of You", "Ed Sheeran", "Pop", "Divide",
                        TimeSpan.FromMinutes(4));
        manager.AddSong("Believer", "Imagine Dragons", "Rock", "Evolve",
                        TimeSpan.FromMinutes(3));
        manager.AddSong("Kesariya", "Arijit Singh", "Bollywood", "Brahmastra",
                        TimeSpan.FromMinutes(4));

        manager.CreatePlaylist("user1", "My Favorites");
        manager.CreatePlaylist("user2", "Workout Mix");
        // -------------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMUSIC STREAMING SERVICE");
            Console.WriteLine("1. Add Song");
            Console.WriteLine("2. Create Playlist");
            Console.WriteLine("3. Add Song to Playlist");
            Console.WriteLine("4. Group Songs by Genre");
            Console.WriteLine("5. View Top Played Songs");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Artist: ");
                    string artist = Console.ReadLine();

                    Console.Write("Genre: ");
                    string genre = Console.ReadLine();

                    Console.Write("Album: ");
                    string album = Console.ReadLine();

                    Console.Write("Duration (minutes): ");
                    int minutes = int.Parse(Console.ReadLine());

                    manager.AddSong(title, artist, genre, album,
                        TimeSpan.FromMinutes(minutes));

                    Console.WriteLine("Song added successfully.");
                    break;

                case 2:
                    Console.Write("User ID: ");
                    string userId = Console.ReadLine();

                    Console.Write("Playlist Name: ");
                    string playlistName = Console.ReadLine();

                    manager.CreatePlaylist(userId, playlistName);
                    Console.WriteLine("Playlist created.");
                    break;

                case 3:
                    Console.WriteLine("\nAvailable Playlists:");
                    foreach (var p in manager.GetAllPlaylists())
                        Console.WriteLine($"{p.PlaylistId} - {p.Name}");

                    Console.Write("Enter Playlist ID: ");
                    string pid = Console.ReadLine();

                    Console.WriteLine("\nAvailable Songs:");
                    foreach (var s in manager.GetAllSongs())
                        Console.WriteLine($"{s.SongId} - {s.Title}");

                    Console.Write("Enter Song ID: ");
                    string sid = Console.ReadLine();

                    bool added = manager.AddSongToPlaylist(pid, sid);
                    Console.WriteLine(added
                        ? "Song added to playlist."
                        : "Operation failed.");
                    break;

                case 4:
                    var grouped = manager.GroupSongsByGenre();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nGenre: {g.Key}");
                        foreach (var s in g.Value)
                            Console.WriteLine($"{s.Title} - {s.Artist}");
                    }
                    break;

                case 5:
                    Console.Write("How many top songs?: ");
                    int count = int.Parse(Console.ReadLine());

                    var topSongs = manager.GetTopPlayedSongs(count);
                    foreach (var s in topSongs)
                        Console.WriteLine($"{s.Title} - Plays: {s.PlayCount}");
                    break;

                case 0:
                    exit = true;
                    Console.WriteLine("Exiting application.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
