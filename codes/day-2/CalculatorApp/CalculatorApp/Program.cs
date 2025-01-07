namespace CalculatorApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Calculator App...");

            Console.Write("enter first number: ");
            //string tempFirst = Console.ReadLine();
            //int firstNumber = int.Parse(tempFirst);
            int firstNumber = int.Parse(Console.ReadLine());

            Console.Write("enter second number: ");
            //string tempSecond = Console.ReadLine();
            //int secondNumber = int.Parse(tempSecond);
            int secondNumber = int.Parse(Console.ReadLine());

            //calling add method
            int addResult = Add(firstNumber, secondNumber);
            //printing result
            //Console.WriteLine($"Add Result: {addResult}");
            // Program.PrintResult("Add", addResult);
            Program.PrintResult(nameof(Add), addResult);

            //calling subtract method
            int subtractResult = Sub(firstNumber, secondNumber);
            //printing result
            //Console.WriteLine($"Subtract Result: {subtractResult}");
            Program.PrintResult(nameof(Sub), subtractResult);

            //calling Multiply method
            int multiplyResult = Multiply(firstNumber, secondNumber);
            //printing result
            Console.WriteLine($"Multiply Result: {multiplyResult}");

            //calling Divide method
            int divideResult = Divide(firstNumber, secondNumber);
            //printing result
            Console.WriteLine($"Divide Result: {divideResult}");
        }

        //static int Add(int first, int second)
        //{
        //    return first + second;
        //}

        //if the method has single line of code
        //new syntax (method body expression syntax)
        static int Add(int first, int second) => first + second;

        //static int Subtract(int first, int second)
        //{
        //    return first - second;
        //}
        static int Sub(int first, int second) => first - second;

        //static int Multiply(int first, int second)
        //{
        //    return first * second;
        //}
        static int Multiply(int first, int second) => first * second;

        //static int Divide(int first, int second)
        //{
        //    return first / second;
        //}
        static int Divide(int first, int second) => first / second;

        static void PrintResult(string methodName, int result) => Console.WriteLine($"{methodName} result: {result}");

        // ==, !=, >, <, >=, <=
    }
}
