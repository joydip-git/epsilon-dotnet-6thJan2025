using ProductManagementSystem.Entities;

namespace ProductManagementSystem.Repository
{
    public class UserRepository(EpsilonDbContext context) : IUserRepository
    {
        public bool AuthenticateUser(User user)
        {
            try
            {
                return context.Users.Any(u => u.UserId == user.UserId && u.Password == user.Password);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RegisterUser(User user)
        {
            try
            {
                var status = context.Users.Any(u => u.UserId == user.UserId && u.Password == user.Password);
                if (!status)
                {
                    context.Users.Add(user);
                    var result = context.SaveChanges();
                    return result > 0;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
