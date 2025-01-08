namespace CalculatorApp
{
    internal class Program
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
                CalcRecord resultRecord = Calculate(choice, first, second);

                //resultRecord.result = 20;
                //resultRecord.method = nameof(Program);

                //resultRecord.Result = 20;
                //resultRecord.Method = nameof(Program);

                //5. print result
                //PrintResult(resultRecord.GetMethod(), resultRecord.GetResult());
                PrintResult(resultRecord.Method, resultRecord.Result);

                //6. decide to continue
                toContinue = GetDecision();
            } while (toContinue != 'n');

        }
        static void PrintMenu() => Console.WriteLine(
            "---MENU---\n1. Add\n2. Subtract\n3. Multiply\n4. Divide"
            );

        static int GetValue()
        {
            Console.Write("enter value: ");
            return int.Parse(Console.ReadLine());
        }

        static int GetChoice()
        {
            Console.Write("\nenter choice[1/2/3/4]: ");
            return int.Parse(Console.ReadLine());
        }

        static char GetDecision()
        {
            Console.Write("\nContinue?[y/Y/n/N]: ");
            char temp = char.Parse(Console.ReadLine());
            return char.IsUpper(temp) ? char.ToLower(temp) : temp;
        }

        static CalcRecord Calculate(int calculationChoice, int firstNumber, int secondNumber)
        {
            CalcRecord calcRecord = new CalcRecord();
            //CalcRecord calcRecord = new CalcRecord(0, null);
            //CalcRecord calcRecord;
            switch (calculationChoice)
            {
                case 1:
                    int addResult = Add(firstNumber, secondNumber);
                    //calcRecord = new CalcRecord(addResult, nameof(Add));
                    //calcRecord.SetReult(addResult);
                    //calcRecord.SetMethod(nameof(Add));
                    calcRecord.Result = addResult;
                    calcRecord.Method = nameof(Add);
                    break;

                case 2:
                    int subResult = Subtract(firstNumber, secondNumber);
                    //calcRecord = new CalcRecord(subResult, nameof(Subtract));
                    calcRecord.Result = subResult;
                    calcRecord.Method = nameof(Subtract);
                    break;

                case 3:
                    int multiResult = Multiply(firstNumber, secondNumber);
                    //calcRecord = new CalcRecord(multiResult, nameof(Multiply));
                    calcRecord.Result = multiResult;
                    calcRecord.Method = nameof(Multiply);
                    break;

                case 4:
                    int divResult = Divide(firstNumber, secondNumber);
                    //calcRecord = new CalcRecord(divResult, nameof(Divide));
                    calcRecord.Result = divResult;
                    calcRecord.Method = nameof(Divide);
                    break;

                default:
                    calcRecord = null;
                    break;
            }
            //int result = calculationChoice switch
            //{
            //    1 => Add(firstNumber, secondNumber),
            //    2 => Subtract(firstNumber, secondNumber),
            //    3 => Multiply(firstNumber, secondNumber),
            //    4 => Divide(firstNumber, secondNumber),
            //    _ => 0,
            //};
            return calcRecord;
        }
        
        static void PrintResult(string methodName, int result) => Console.WriteLine($"{methodName} result: {result}");

        static int Add(int first, int second) => first + second;

        static int Subtract(int first, int second) => first - second;

        static int Multiply(int first, int second) => first * second;

        static int Divide(int first, int second) => first / second;

    }
}
