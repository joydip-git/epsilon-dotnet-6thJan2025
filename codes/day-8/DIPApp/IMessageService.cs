namespace DIPApp;

public interface IMessageService
{
    bool Validate(string email);
    bool SendMessage(string message, string? email = null);
}
