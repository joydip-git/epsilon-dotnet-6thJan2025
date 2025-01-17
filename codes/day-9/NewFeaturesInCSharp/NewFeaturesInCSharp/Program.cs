//using NewFeaturesInCSharp.Utilities;

//static import (6.0)
using static NewFeaturesInCSharp.Utilities.Utility;

namespace NewFeaturesInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Utility.PrintMenu();
            PrintMenu();

            int choice = GetChoice();
            //Console.WriteLine("choice made by user is " + choice);

            //string interpolation (6.0)
            Console.WriteLine($"choice made by user is {choice}");

            //Person anilPerson = new Person();
            //or
            //new style of calling constructor
            //Person anilPerson = new();            
            //anilPerson.Name = "Anil";
            //anilPerson.Id = 1;

            //object initializer (3.0)
            Person joydipPerson = new Person { Name = "joydip", Id = 3 };
            //or
            Person sunilPerson = new() { Name = "sunil", Id = 2 };

            //nullable value types (2.0)
            int? x = 10;
            Console.WriteLine(x);
            //or
            Nullable<int> y = 20;
            if (y.HasValue)
                Console.WriteLine(y);
            else
                Console.WriteLine("no value");

            Console.WriteLine($"Hash Code of y: {y?.GetHashCode()}");

            //Name property is mandatory to be used
            //Person? maheshPerson = new() { Id = 4 };

            Person? maheshPerson = null;
            maheshPerson = new() { Name = "Mahesh", Id = 4 };
            //null conditional operator or null propagator (6.0 => ?. or ?[])
            Console.WriteLine($"Name={maheshPerson?.Name} and Id={maheshPerson?.Id} and Marks: {maheshPerson?.Marks?[0]}");

            try
            {
                maheshPerson?.Equals(12);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
