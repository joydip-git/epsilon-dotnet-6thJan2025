namespace SRPApp
{
    public class UserService
    {
        private readonly EmailService emailService;
        public UserService()
        {
            this.emailService = new EmailService();
        }
        public void RegisterUser(string email, string strongPassword)
        {
            if (!emailService.ValidateEmail(email))
            {
                throw new Exception($"{email} is invalid mail id");
            }
            emailService.SendEmail("Happ New Year 2025...", email);
        }
    }
}