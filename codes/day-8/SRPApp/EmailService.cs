using System.Net.Mail;

namespace SRPApp;

public class EmailService
{
    private readonly SmtpClient smtpClient;

    public EmailService()
    {
        smtpClient = new SmtpClient();
    }
    public virtual bool ValidateEmail(string email)
    {
        return email.Contains("@");
    }
    public bool SendEmail(string message, string email)
    {
        MailMessage mailMessage = new("joydip@gmail.com", email, "HAPPY NEW YEAR", message);
        smtpClient.Send(mailMessage);
        return true;
    }
}
