namespace CalculatorApp.Utilities
{
    static class UIUtility
    {
        public static void PrintMenu() => Console.WriteLine(
           "---MENU---\n1. Add\n2. Subtract\n3. Multiply\n4. Divide"
           );

        public static int GetValue()
        {
            Console.Write("enter value: ");
            return int.Parse(Console.ReadLine());
        }

        public static int GetChoice()
        {
            Console.Write("\nenter choice[1/2/3/4]: ");
            return int.Parse(Console.ReadLine());
        }

        public static char GetDecision()
        {
            Console.Write("\nContinue?[y/Y/n/N]: ");
            char temp = char.Parse(Console.ReadLine());
            return char.IsUpper(temp) ? char.ToLower(temp) : temp;
        }

        public static void PrintResult(string methodName, int result) => Console.WriteLine($"{methodName} result: {result}");
    }
}
