using CalculationLibrary;
using CalculationExtensionLibrary;
using ComplexCalculationLibrary;

namespace NewFeaturesOfCSharp_Part3
{
    internal class Program
    {
        static void Main()
        {
            SimpleCalculator simpleCalculator = new();
            Console.WriteLine(simpleCalculator.Add(12, 13));
            Console.WriteLine(simpleCalculator.Subtract(12, 3));

            ComplexCalculator complexCalculator = new();
            Console.WriteLine(complexCalculator.Multiply(12,3));
            Console.WriteLine(complexCalculator.Subtract(12, 3));

            string name = "joydip";
            Console.WriteLine(name.SayHello());
        }
    }
}
