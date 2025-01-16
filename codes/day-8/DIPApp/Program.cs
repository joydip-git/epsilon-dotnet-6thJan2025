namespace DIPApp;

public class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("1. via mail 2. via whats app");
            Console.WriteLine("\nenter message service[1/2]: ");
            int choice = int.Parse(Console.ReadLine() ?? "1");

            //Factory factory = new(choice);
            Factory factory = Factory.Instantiate();
            //Factory factory1 = Factory.Instantiate();
            IMessageService? messageService = factory.CreateServiceInstance(choice);
            if (messageService != null)
            {
                UserService userService = new(messageService);
                userService.RegisterUser("sainath@epsilon.com", "Sainath@123");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex}");
        }
    }
}
