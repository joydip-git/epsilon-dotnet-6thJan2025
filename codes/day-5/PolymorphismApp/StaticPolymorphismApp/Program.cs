namespace StaticPolymorphismApp
{
    internal class Program
    {
        static void Main()
        {
            Calculation calculation = new Calculation();
            calculation.Add(12, 13, 145678912345);

            int a = 10;
            int b = 20;
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else
                Console.WriteLine(b);

            Person anilPerson = new Person { Id = 1, FirstName = "anil", LastName = "kumar" };
            Person sunilPerson = new Person { Id = 2, FirstName = "sunil", LastName = "gupta" };

            if (anilPerson > sunilPerson)
            {
                Console.WriteLine($"{anilPerson.LastName} is greater than {sunilPerson.LastName}");
            }
            else
            {
                Console.WriteLine($"{sunilPerson.LastName} is greater than {anilPerson.LastName}");
            }


            Person joydipPerson = new() { Id = 1, FirstName = "joydip", LastName = "mondal" };
            Person saiPerson = new() { Id = 1, FirstName = "joydip", LastName = "mondal" };

            if (joydipPerson == saiPerson)
            {
                Console.WriteLine("same");
            }
            else
                Console.WriteLine("not same");
        }
    }
}
