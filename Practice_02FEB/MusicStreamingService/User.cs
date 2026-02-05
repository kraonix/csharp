using System.Collections.Generic;

public class User
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public List<string> FavoriteGenres { get; set; } = new();
    public List<Playlist> UserPlaylists { get; set; } = new();
}
