using ProductManagementSystem.Entities;

namespace ProductManagementSystem.Repository
{
    public interface IUserRepository
    {
        bool AuthenticateUser(User user);
        bool RegisterUser(User user);
    }
}