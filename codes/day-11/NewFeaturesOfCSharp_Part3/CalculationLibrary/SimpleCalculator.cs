using CalculationContractLibrary;

namespace CalculationLibrary
{
    public class SimpleCalculator : ICalculator
    {
        public int Add(int x, int y) => x + y;
    }
}
