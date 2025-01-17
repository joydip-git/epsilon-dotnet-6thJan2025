using System.Net.Mail;

namespace DIPApp
{
    //low-level module
    public class EmailService : IMessageService
    {
        private readonly SmtpClient smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient;
        }
        public virtual bool Validate(string email)
        {
            return email.Contains("@");
        }
        public bool SendMessage(string message, string? email = null)
        {
            if (email != null)
            {
                MailMessage mailMessage = new("joydip@gmail.com", email, "HAPPY NEW YEAR", message);
                smtpClient.Send(mailMessage);
                return true;
            }
            else
                return false;
        }
    }
}
