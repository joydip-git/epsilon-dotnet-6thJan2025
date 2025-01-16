namespace DIPApp;

public class WhatsAppMessageService : IMessageService
{
    public bool SendMessage(string message, string? email = null)
    {
        return true;
    }

    public bool Validate(string email)
    {
        return true;
    }

}
