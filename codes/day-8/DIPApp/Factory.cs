using System.Net.Mail;
namespace DIPApp;

//IoC container
public class Factory
{
    private static Factory? factory = null;
    private Factory()
    {
        Console.WriteLine("factory created....");
    }

    public static Factory Instantiate()
    {
        // if (factory == null)
        //     factory = new Factory(choice);

        factory ??= new Factory();
        return factory;
    }
    public IMessageService? CreateServiceInstance(int choice = 1)
    {
        IMessageService? messageService;

        switch (choice)
        {
            case 1:
                messageService = new EmailService(new SmtpClient());
                break;

            case 2:
                messageService = new WhatsAppMessageService();
                break;

            default:
                messageService = null;
                break;
        }

        return messageService;

        // return new EmailService(new SmtpClient("", 8080));
    }
}
