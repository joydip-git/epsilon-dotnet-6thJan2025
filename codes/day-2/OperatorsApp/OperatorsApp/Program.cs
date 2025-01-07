namespace OperatorsApp
{
    internal class Program
    {
        static void Main()
        {
            int x = 5;
            int y = 10;
            int result;

            //result = x & y;
            //Console.WriteLine($"Bitwise AND: {result}");

            //result = x | y;
            //Console.WriteLine($"Bitwise OR: {result}");

            //result = x >> 2;
            //Console.WriteLine($"Bitwise Right Shift: {result}");

            //result = x > y ? x : y;
            //Console.WriteLine($"Result: {result}");

            if (x > y)
            {
                //if()
                //{ }
                result = x;
            }
            else
                result = y;

            Console.WriteLine($"Result: {result}");

            Console.Write("enter choice: ");
            int choice = int.Parse(Console.ReadLine());
            //if (choice == 1)
            //{

            //}
            //else if (choice == 2)
            //{
            //}
            //else
            //{

            //}
            switch (choice)
            {
                case 1:
                    Console.WriteLine("1");
                    break;

                case 2:
                    Console.WriteLine("2");
                    break;

                default:
                    Console.WriteLine("something..");
                    break;
            }
        }
    }
}
