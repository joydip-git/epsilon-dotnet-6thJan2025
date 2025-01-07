namespace ClassAndObjectApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            //Console.WriteLine(consoleKeyInfo.KeyChar);
            //Console.WriteLine(consoleKeyInfo.Key);

            //Console.Write("enter a value: ");
            //Console.WriteLine(Console.Read());

            //calling static method (no need to create instance/object of Program class to call SayHello method)
            string message = Program.SayHello("joydip");
            Console.WriteLine(message);


            //calling static method (no need to create instance/object of Program class to call AcceptUserInfo method)
            Person joydipPersonRef = Program.AcceptUserInfo();

            //calling instance method (need to create instance/object of Person class to call PrintValues method)
            joydipPersonRef.PrintValues();
            
            Person karthikPersonef = Program.   AcceptUserInfo();
            karthikPersonef.PrintValues();
        }

        static Person AcceptUserInfo()
        {
            Console.Write("enter id: ");
            string tempId = Console.ReadLine(); //1001 -> "1001"
            //explicit conversion (string -> int)
            int id = int.Parse(tempId);

            Console.Write("enter name: ");
            string name = Console.ReadLine();

            Console.Write("enter mobile no: ");
            string tempMob = Console.ReadLine(); //90900... -> "9090..."

            //explicit conversion (string -> long)
            long mobile = long.Parse(tempMob);

            //Person person = new Person(id, name, mobile);

            //new syntax
            Person person = new(id, name, mobile);
            return person;
        }

        static string SayHello(string name)
        {
            string welcomeMessage = "Hello " + name;
            return welcomeMessage;
        }
    }
}
