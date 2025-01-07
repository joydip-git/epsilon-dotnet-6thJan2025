namespace ClassAndObjectApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = SayHello("joydip");
            Console.WriteLine(message);

            Person joydipPersonRef = AcceptUserInfo();
            Person karthikPersonef = AcceptUserInfo();
        }

        static Person AcceptUserInfo()
        {
            Console.WriteLine("enter id: ");
            string tempId = Console.ReadLine(); //1001 -> "1001"
            int id = int.Parse(tempId);

            Console.WriteLine("enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("enter mobile no: ");
            string tempMob = Console.ReadLine(); //90900... -> "9090..."
            long mobile = long.Parse(tempMob);

            Person person = new Person(id, name, mobile);
            return person;
        }

        static string SayHello(string name)
        {
            string welcomeMessage = "Hello " + name;
            return welcomeMessage;
        }
    }
}
