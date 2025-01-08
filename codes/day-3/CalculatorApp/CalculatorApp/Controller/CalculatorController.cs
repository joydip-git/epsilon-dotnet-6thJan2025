using CalculatorApp.Models;
using CalculatorApp.Service;

namespace CalculatorApp.Controller
{
    class CalculatorController
    {
        public CalculationOutput Calculate(int calculationChoice, int firstNumber, int secondNumber)
        {
            CalculationService calculationService = new CalculationService();

            CalculationOutput output;
            switch (calculationChoice)
            {
                case 1:
                    int addResult = calculationService.Add(firstNumber, secondNumber);
                    output = new CalculationOutput(addResult, nameof(calculationService.Add));
                    break;

                case 2:
                    int subResult = calculationService.Subtract(firstNumber, secondNumber);
                    output = new CalculationOutput(subResult, nameof(calculationService.Subtract));
                    break;

                case 3:
                    int multiResult = calculationService.Multiply(firstNumber, secondNumber);
                    output = new CalculationOutput(multiResult, nameof(calculationService.Multiply));
                    break;

                case 4:
                    int divResult = calculationService.Divide(firstNumber, secondNumber);
                    output = new CalculationOutput(divResult, nameof(calculationService.Divide));
                    break;

                default:
                    output = null;
                    break;
            }
            return output;
        }
    }
}
