using UserServiceAPI.Models;
using UserServiceAPI.Repositories;

namespace UserServiceAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public List<User> GetUsers()
    {
        return _repository.GetAll();
    }

    public User? GetUser(int id)
    {
        return _repository.GetById(id);
    }

    public void CreateUser(User user)
    {
        _repository.Add(user);
    }

    public void UpdateUser(User user)
    {
        _repository.Update(user);
    }

    public void DeleteUser(int id)
    {
        _repository.Delete(id);
    }
}