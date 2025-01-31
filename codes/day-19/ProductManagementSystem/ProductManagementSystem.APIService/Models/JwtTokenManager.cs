using ProductManagementSystem.Entities;

namespace ProductManagementSystem.APIService.Models
{
    public class JwtTokenManager : ITokenManager
    {
        public string GenerateJSONWebToken(User user)
        {
            try
            {               
                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
