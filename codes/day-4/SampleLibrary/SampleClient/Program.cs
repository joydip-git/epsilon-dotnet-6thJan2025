using MessengerApp;

namespace SampleClient
{
    internal class Program
    {
        static void Main()
        {
            Messenger messenger = new();
            Console.WriteLine(messenger.GetMessage("Venkatesh"));
        }
    }
}
