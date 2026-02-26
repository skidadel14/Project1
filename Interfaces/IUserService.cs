using MyFirstProject.Models;

namespace MyFirstProject.Interfaces;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
    void Register(User user);
}