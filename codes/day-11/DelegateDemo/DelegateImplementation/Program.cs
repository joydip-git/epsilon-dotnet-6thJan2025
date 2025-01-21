namespace DelegateImplementation;

class Program
{
    static IEnumerable<string> Filter(List<string> input, StringLogicInvoker logicInvoker)
    {
        List<string> result = [];
        if (input != null && input.Count > 0)
        {
            foreach (var item in input)
            {
                bool isTrue = logicInvoker(item);
                if (isTrue)
                    result.Add(item);
            }
        }
        return result;
    }

    static IEnumerable<int> Filter(List<int> input, NumericalLogicInvoker logicInvoker)
    {
        List<int> result = [];
        if (input != null && input.Count > 0)
        {
            foreach (var item in input)
            {
                //logicInvoker.Invoke(item);
                bool isTrue = logicInvoker(item);
                if (isTrue)
                    result.Add(item);
            }
        }
        return result;
    }

    static IEnumerable<T> Filter<T>(List<T> input, LogicInvoker<T> logicInvoker)
    {
        List<T> result = [];
        if (input != null && input.Count > 0)
        {
            foreach (T item in input)
            {
                bool isTrue = logicInvoker(item);
                if (isTrue)
                    result.Add(item);
            }
        }
        return result;
    }

    public static void Main()
    {
        //collection initializer
        //data source
        List<int> numbers = [1, 3, 4, 2, 7, 5, 0, 6, 9, 8];

        //logic to filter the source of data 
        Logic logic = new();
        //NumericalLogicInvoker evenDel = new(logic.IsEven);
        LogicInvoker<int> evenDel = new(logic.IsEven);

        //the Filter method accepts two arguments:
        //a. the source of data
        //b. the delegate, with reference to the method, whose logic should be applied on every value in that source of data
        var evenNumbers = Filter(numbers, evenDel);
        if (evenNumbers.Count()>0)
        {
            Console.WriteLine("printing even numbers\n");
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }
        }
        else
            Console.WriteLine("no result");

        //NumericalLogicInvoker oddDel = new(Logic.IsOdd);
        LogicInvoker<int> oddDel = new(Logic.IsOdd);

        var oddNumbers = Filter(numbers, oddDel);
        if (oddNumbers.Count() > 0)
        {
            Console.WriteLine("\nprinting odd numbers\n");
            foreach (var item in oddNumbers)
            {
                Console.WriteLine(item);
            }
        }
        else
            Console.WriteLine("no result");

        //LogicInvoker lessThanFiveDel = new LogicInvoker(
        //    delegate (int x)
        //    {
        //        return x < 5;
        //    }
        //);

        //LogicInvoker lessThanFiveDel = delegate (int x)
        //{
        //    return x < 5;
        //};

        //Lambda expression
        //LogicInvoker lessThanFiveDel = (int x) =>
        //{
        //    return x < 5;
        //};

        //Lambda expression with expression body syntax
        //without data type of argument, as C# will automatically infer the data type from delegate signature

        //NumericalLogicInvoker lessThanFiveDel = (x) => x < 5;
        LogicInvoker<int> lessThanFiveDel = (x) => x < 5;

        var lessThanFiveNumbers = Filter(numbers, lessThanFiveDel);
        if (lessThanFiveNumbers.Count() > 0)
        {
            Console.WriteLine("\nprinting less than five numbers\n");
            foreach (var item in lessThanFiveNumbers)
            {
                Console.WriteLine(item);
            }
        }
        else
            Console.WriteLine("no result");



        //data source
        List<string> people = ["anil", "sunil", "joydip"];

        //logic to filter the people list, where whether the name contains a letter 'n' or not
        //StringLogicInvoker filterByN = (name) => name.Contains<char>('n');
        LogicInvoker<string> filterByN= (name) => name.Contains<char>('n');

        var peopleWithN = Filter(people, filterByN);
        if (peopleWithN.Count() > 0)
        {
            Console.WriteLine("\nprinting people with 'n' in their name\n");
            foreach (var item in peopleWithN)
            {
                Console.WriteLine(item);
            }
        }
        else
            Console.WriteLine("no result");
    }
}
