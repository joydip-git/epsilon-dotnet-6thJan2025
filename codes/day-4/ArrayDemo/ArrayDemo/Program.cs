namespace ArrayDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];
            //numbers[0] = 10;
            //numbers[1] = 20;
            //numbers[2] = 30;

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"enter value at numbers[{i}]: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\n");
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine($"value at numbers[{i}]: {numbers[i]}");
            //}
            foreach (int intValue in numbers)
            {
                Console.WriteLine($"value: {intValue}");
            }

            int[,] twoDimNumbers = new int[2, 3];
            Console.WriteLine($"Length:{twoDimNumbers.Length}");
            //twoDimNumbers[0, 0] = 10;
            //twoDimNumbers[0, 1] = 20;
            //twoDimNumbers[0, 2] = 30;

            //twoDimNumbers[1, 0] = 40;
            //twoDimNumbers[1, 1] = 50;
            //twoDimNumbers[1, 2] = 60;

            Console.WriteLine("\n");
            for (int rowIndex = 0; rowIndex < twoDimNumbers.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < twoDimNumbers.GetLength(1); columnIndex++)
                {
                    Console.Write($"enter value at twoDimNumbers[{rowIndex},{columnIndex}]: ");
                    twoDimNumbers[rowIndex, columnIndex] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("\n");
            }

            //row:0
            //Console.WriteLine($"Length of 1st dimension (row): {twoDimNumbers.GetLength(0)}");
            //column:1
            //Console.WriteLine($"Length of 2nd dimension (column): {twoDimNumbers.GetLength(1)}");
            Console.WriteLine("\n");

            for (int rowIndex = 0; rowIndex < twoDimNumbers.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < twoDimNumbers.GetLength(1); columnIndex++)
                {
                    Console.WriteLine($"value at twoDimNumbers[{rowIndex},{columnIndex}]: {twoDimNumbers[rowIndex, columnIndex]}");
                }
                Console.WriteLine("\n");
            }

            //string[] names = new string[3];
            //string[] names = { "anil", "sunil", "manoj" };
            string[] names = ["anil", "sunil", "manoj"];
            foreach (var name in names)
            {
                Console.WriteLine($"Name:{name}");
            }

            //calling parameterized ctor
            Person anilPerson = new(1, "anil");
            //calling default ctor and using properties later
            Person manojPerson = new();
            manojPerson.Id = 3;
            manojPerson.Name = "Manoj";
            //Object initialization
            //Person sunilPerson = new Person() { Id = 2, Name = "sunil" };
            //or
            //Person sunilPerson = new Person { Id = 2, Name = "sunil" };
            //or
            //Person sunilPerson = new() { Id = 2, Name = "sunil" };
            //or
            var sunilPerson = new Person { Id = 2, Name = "sunil" };

            //creating instance of an array of size 3, where every memory block (index position) of the array will store a reference of Person class instance
            //NOTE: you are not creating instance of Person, but instance of an array

            //Person[] people = new Person[3];
            //people[0] = anilPerson;
            //people[1] = sunilPerson;
            //people[2] = manojPerson;

            //or
            //Person[] people = [anilPerson, sunilPerson, manojPerson];

            //or (implictly typed array variable)
            var people = new Person[] { anilPerson, sunilPerson, manojPerson };

            //foreach(<type-element-in-collection> <var-name> in <collection-data-structure>)
            foreach (Person person in people)
            {
                Console.WriteLine($"Id:{person.Id}, Name:{person.Name}");
            }

            //x -> implcitly typed local variable
            //C# uses type-inference (resolving the data type of the variable, declared with var keyword, from the assigned value)
            //NOTE: var is JUST a keyword, NOT a data type
            //you must assign vakue to the variable for C# to resolve the data type
            //should not ues as paremeter or return type of a method
            //should not use to declare data members of a class
            //try to avoid declaration using var keyword unnecessarily, wher the data type of the variable is known
            var x = 10; //-> good practice: int x = 10;
            Console.WriteLine(x);
        }
    }
}
