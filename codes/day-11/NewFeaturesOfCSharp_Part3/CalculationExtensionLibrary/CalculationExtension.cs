using CalculationContractLibrary;
//using CalculationLibrary;
//using ComplexCalculationLibrary;

namespace CalculationExtensionLibrary
{
    public static class CalculationExtension
    {
        //extension method
        //first argument: this <target-type> parameter-name
        //this method will be added as "instance" method to the target type
        //Note: only one target type can be mentioned
        //target-type can be user-defined type

        //public static int Subtract(this SimpleCalculator calc, int x, int y) => x - y;

        //if you want the same Subtract method to be added to another target type, then write it once more
        //public static int Subtract(this ComplexCalculator calc, int x, int y) => x - y;

        //if you want to add the Subtract method to multiple classes as an extension method, create a base interface (even if its blank interface), and then add the Subtract method to that interface
        //the following code means: adding the Subtract method as an extension method to any class, which implement the ICalculator interface
        public static int Subtract(this ICalculator calculator, int x, int y) => x - y;

        //target type can be even built-in types
        public static string SayHello(this string str) => $"Hello, {str}";
    }
}
