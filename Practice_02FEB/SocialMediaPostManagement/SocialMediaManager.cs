using System;
using System.Collections.Generic;
using System.Linq;

public class SocialMediaManager
{
    private readonly List<User> _users = new();
    private readonly List<Post> _posts = new();

    private int _userCounter = 1;
    private int _postCounter = 1;

    // Register User
    public void RegisterUser(string userName, string bio)
    {
        _users.Add(new User
        {
            UserId = $"U{_userCounter:D3}",
            UserName = userName,
            Bio = bio,
            FollowersCount = 0
        });
        _userCounter++;
    }

    // Create Post
    public void CreatePost(string userId, string content, string type)
    {
        if (!_users.Any(u => u.UserId == userId))
            return;

        _posts.Add(new Post
        {
            PostId = $"P{_postCounter:D3}",
            UserId = userId,
            Content = content,
            PostType = type,
            PostTime = DateTime.Now,
            Likes = 0
        });
        _postCounter++;
    }

    // Like Post
    public void LikePost(string postId, string userId)
    {
        var post = _posts.FirstOrDefault(p => p.PostId == postId);
        if (post != null)
            post.Likes++;
    }

    // Add Comment
    public void AddComment(string postId, string userId, string comment)
    {
        var post = _posts.FirstOrDefault(p => p.PostId == postId);
        if (post != null)
            post.Comments.Add($"{userId}: {comment}");
    }

    // Group Posts by User
    public Dictionary<string, List<Post>> GroupPostsByUser()
    {
        return _posts
            .GroupBy(p => p.UserId)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Trending Posts
    public List<Post> GetTrendingPosts(int minLikes)
    {
        return _posts
            .Where(p => p.Likes >= minLikes)
            .OrderByDescending(p => p.Likes)
            .ToList();
    }

    // Helpers for menu
    public List<User> GetAllUsers() => _users;
    public List<Post> GetAllPosts() => _posts;
}
