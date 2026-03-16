using UserServiceAPI.Models;

namespace UserServiceAPI.Services;

public interface IUserService
{
    List<User> GetUsers();

    User? GetUser(int id);

    void CreateUser(User user);

    void UpdateUser(User user);

    void DeleteUser(int id);
}