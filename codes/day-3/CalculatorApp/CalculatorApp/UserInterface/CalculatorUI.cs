using CalculatorApp.Controller;
using CalculatorApp.Models;
//static import (import the static class itself)
using static CalculatorApp.Utilities.UIUtility;

namespace CalculatorApp.UserInterface
{
    internal class CalculatorUI
    {
        static void Main()
        {
            Console.WriteLine("Calculator App...");
            char toContinue;
            do
            {
                //1. printing menu
                PrintMenu();

                //2. get choice from user
                int choice = GetChoice();

                //3. get values from user
                int first = GetValue();
                int second = GetValue();

                //4. perform calculation
                CalculatorController calculatorController = new CalculatorController();

                CalculationOutput resultRecord = calculatorController.Calculate(choice, first, second);

                //5. print result
                PrintResult(resultRecord.Method, resultRecord.Result);

                //6. decide to continue
                toContinue = GetDecision();

            } while (toContinue != 'n');

        }
    }
}
