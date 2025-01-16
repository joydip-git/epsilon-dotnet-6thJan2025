using Microsoft.Data.SqlClient;
using SampleLibrary;

namespace SampleClientApp
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello, World!");
            Messenger messenger = new();
            string message = messenger.GetMessage("joydip");
            Console.WriteLine($"Message: {message}");
            SqlConnection connection = new SqlConnection("");
        }
    }
}

