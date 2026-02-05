using System;

class Program
{
    static void Main()
    {
        SocialMediaManager manager = new SocialMediaManager();

        // -------- Hardcoded Initial Data --------
        manager.RegisterUser("Sachin", "Tech enthusiast");
        manager.RegisterUser("Neha", "Love travelling");

        manager.CreatePost("U001", "Hello world! My first post", "Text");
        manager.CreatePost("U002", "Sunset view from the hills", "Image");

        manager.LikePost("P001", "U002");
        manager.LikePost("P001", "U001");
        manager.AddComment("P002", "U001", "Beautiful view!");
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nSOCIAL MEDIA POST MANAGEMENT");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Create Post");
            Console.WriteLine("3. Like Post");
            Console.WriteLine("4. Add Comment");
            Console.WriteLine("5. Group Posts by User");
            Console.WriteLine("6. View Trending Posts");
            Console.WriteLine("7. View All Posts");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("User Name: ");
                    string uname = Console.ReadLine();

                    Console.Write("Bio: ");
                    string bio = Console.ReadLine();

                    manager.RegisterUser(uname, bio);
                    Console.WriteLine("User registered successfully.");
                    break;

                case 2:
                    Console.WriteLine("Users:");
                    foreach (var u in manager.GetAllUsers())
                        Console.WriteLine($"{u.UserId} - {u.UserName}");

                    Console.Write("User ID: ");
                    string uid = Console.ReadLine();

                    Console.Write("Content: ");
                    string content = Console.ReadLine();

                    Console.Write("Post Type (Text/Image/Video): ");
                    string type = Console.ReadLine();

                    manager.CreatePost(uid, content, type);
                    Console.WriteLine("Post created successfully.");
                    break;

                case 3:
                    Console.WriteLine("Posts:");
                    foreach (var p in manager.GetAllPosts())
                        Console.WriteLine($"{p.PostId} - {p.Content}");

                    Console.Write("Post ID: ");
                    string pid = Console.ReadLine();

                    Console.Write("User ID: ");
                    string liker = Console.ReadLine();

                    manager.LikePost(pid, liker);
                    Console.WriteLine("Post liked.");
                    break;

                case 4:
                    Console.Write("Post ID: ");
                    string cpid = Console.ReadLine();

                    Console.Write("User ID: ");
                    string cuid = Console.ReadLine();

                    Console.Write("Comment: ");
                    string comment = Console.ReadLine();

                    manager.AddComment(cpid, cuid, comment);
                    Console.WriteLine("Comment added.");
                    break;

                case 5:
                    var grouped = manager.GroupPostsByUser();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nUser ID: {g.Key}");
                        foreach (var p in g.Value)
                            Console.WriteLine($"{p.PostId} - {p.Content}");
                    }
                    break;

                case 6:
                    Console.Write("Minimum Likes: ");
                    int minLikes = int.Parse(Console.ReadLine());

                    var trending = manager.GetTrendingPosts(minLikes);
                    foreach (var p in trending)
                    {
                        Console.WriteLine(
                            $"{p.PostId} | Likes: {p.Likes} | {p.Content}");
                    }
                    break;

                case 7:
                    foreach (var p in manager.GetAllPosts())
                    {
                        Console.WriteLine(
                            $"{p.PostId} | {p.PostType} | Likes: {p.Likes}");
                    }
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
