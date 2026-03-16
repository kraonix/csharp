using UserServiceAPI.Models;

namespace UserServiceAPI.Repositories;

public class UserRepository : IUserRepository
{
    private static List<User> users = new List<User>()
    {
        new User { Id = 1, Name = "Sachin", Email = "sachin@mail.com" },
        new User { Id = 2, Name = "Arzoo", Email = "arzoo@mail.com" },
        new User { Id = 3, Name = "Neeraj", Email = "neeraj@mail.com" }
    };

    public List<User> GetAll()
    {
        return users;
    }

    public User? GetById(int id)
    {
        return users.FirstOrDefault(x => x.Id == id);
    }

    public void Add(User user)
    {
        user.Id = users.Max(x => x.Id) + 1;
        users.Add(user);
    }

    public void Update(User user)
    {
        var existingUser = users.FirstOrDefault(x => x.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
        }
    }

    public void Delete(int id)
    {
        var user = users.FirstOrDefault(x => x.Id == id);
        if (user != null)
            users.Remove(user);
    }
}