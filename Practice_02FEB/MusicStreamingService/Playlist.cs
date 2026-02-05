using System.Collections.Generic;

public class Playlist
{
    public string PlaylistId { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public List<Song> Songs { get; set; } = new();
}
