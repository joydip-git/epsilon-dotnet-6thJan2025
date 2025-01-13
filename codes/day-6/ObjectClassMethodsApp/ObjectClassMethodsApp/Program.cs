namespace ObjectClassMethodsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person anilPerson = new(1, "anil", 1000);
            //Console.WriteLine($"Id:{anilPerson.Id},Name:{anilPerson.Name},Salary:{anilPerson.Salary}");
            //Console.WriteLine(anilPerson.ToString());

            //when printing the reference, actually ToString() gets invoked by default
            //if you have NOT overriden the ToString() method, then the base class (Object) ToString() method will be invoked, which will print the data type of this object (along with namespace name)
            //output => ObjectClassMethodsApp.Person
            Console.WriteLine(anilPerson);

            //GetType() method returns an instance of another class, known as Type, storing information about Person class (such as: fully qualified name [name of the type along with namespace name], name (type name), which are the data members, methods, constructors, properties etc. written inside the class etc.)
            Type personType = anilPerson.GetType();
            Console.WriteLine($"Name:{personType.Name}");
            Console.WriteLine($"Fully Qualified Name:{personType.FullName}");

            //anoter way to extract type information (using typeof operator)
            //Type personClsType = typeof(Person);
            //Console.WriteLine($"Name:{personClsType.Name}");
            //Console.WriteLine($"Fully Qualified Name:{personClsType.FullName}");

            //Person sunilPerson = anilPerson;
            Person sunilPerson = new(1, "anil", 1000);

            //Person joydipPerson = sunilPerson;
            //Person joydipPerson = new(3, "joydip", 3000);

            // anilPerson -> current instance
            // sunilPerson -> other instance

            if (anilPerson.GetHashCode() == sunilPerson.GetHashCode())
            {
                if (anilPerson == sunilPerson)
                //if (anilPerson.Equals(sunilPerson))
                {
                    Console.WriteLine("same");
                }
                else
                    Console.WriteLine("not same");
            }
            else
                Console.WriteLine("not same");
        }
    }
}
