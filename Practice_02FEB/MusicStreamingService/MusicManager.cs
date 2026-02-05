using System;
using System.Collections.Generic;
using System.Linq;

public class MusicManager
{
    private readonly List<Song> _songs = new();
    private readonly List<User> _users = new();
    private readonly List<Playlist> _playlists = new();

    // Add Song
    public void AddSong(string title, string artist, string genre,
                        string album, TimeSpan duration)
    {
        _songs.Add(new Song
        {
            SongId = Guid.NewGuid().ToString(),
            Title = title,
            Artist = artist,
            Genre = genre,
            Album = album,
            Duration = duration,
            PlayCount = 0
        });
    }

    // Create Playlist
    public void CreatePlaylist(string userId, string playlistName)
    {
        var user = _users.FirstOrDefault(u => u.UserId == userId);
        if (user == null)
        {
            user = new User { UserId = userId, UserName = userId };
            _users.Add(user);
        }

        var playlist = new Playlist
        {
            PlaylistId = Guid.NewGuid().ToString(),
            Name = playlistName,
            CreatedBy = userId
        };

        user.UserPlaylists.Add(playlist);
        _playlists.Add(playlist);
    }

    // Add Song to Playlist
    public bool AddSongToPlaylist(string playlistId, string songId)
    {
        var playlist = _playlists.FirstOrDefault(p => p.PlaylistId == playlistId);
        var song = _songs.FirstOrDefault(s => s.SongId == songId);

        if (playlist == null || song == null)
            return false;

        playlist.Songs.Add(song);
        song.PlayCount++;
        return true;
    }

    // Group Songs by Genre
    public Dictionary<string, List<Song>> GroupSongsByGenre()
    {
        return _songs
            .GroupBy(s => s.Genre)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Get Top Played Songs
    public List<Song> GetTopPlayedSongs(int count)
    {
        return _songs
            .OrderByDescending(s => s.PlayCount)
            .Take(count)
            .ToList();
    }

    // Helper methods for menu
    public List<Song> GetAllSongs() => _songs;
    public List<Playlist> GetAllPlaylists() => _playlists;
}
