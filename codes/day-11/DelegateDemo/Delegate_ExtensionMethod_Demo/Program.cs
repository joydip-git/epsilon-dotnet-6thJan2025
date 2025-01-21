namespace Delegate_ExtensionMethod_Demo
{
    internal class Program
    {
        static void Main()
        {
            //bulit-in delegates of .NET library

            //1. Action delegate: delegate void Action<in T>(T obj);
            Action<string> printDel = (name) => Console.WriteLine(name);

            //2. Predicate delegate:
            //delegate bool Predicate<in T>(T obj);
            Predicate<int> evenDel = (num) => num % 2 == 0;

            //3. Func delegate
            //version-1: delegate TResult Func<out TResult>();
            Func<string> getNameDel = () => "joydip";
            //version-2: delegate TResult Func<in T, out TResult>(T obj);
            Func<int, bool> oddDel = (num) => num % 2 != 0;
            //version-3: delegate TResult Func<in T1, in T2, out TResult>(T1 x,T2 y);
            //Func<int, int, bool> compareDel = (x, y) => x > y;
            Func<int, int, int> compareDel = (x, y) => x - y;

            //data source
            List<int> numbers = [1, 3, 4, 2, 7, 5, 0, 6, 9, 8];

            //filtration
            IEnumerable<int> oddNumbers = numbers.Where(oddDel);

            //sorting
            Func<int, int> sortDel = x => x;
            IOrderedEnumerable<int> sortedResult = oddNumbers.OrderBy(sortDel);
            List<int> result = sortedResult.ToList();

            //printing
            Action<int> printResultDel = (num) => Console.WriteLine(num);
            Console.WriteLine("\nprint odd numbers in ascending order\n");
            result.ForEach(printResultDel);

            //functional programming
            //foundation: OOP concepts, generic concept, collections, delegate concept and new features of C#
            Console.WriteLine("\nprint even numbers in descending order\n");
            numbers
                .Where((x) => x % 2 == 0)
                .OrderByDescending(x => x)
                .ToList()
                .ForEach((x) => Console.WriteLine(x));

            //LINQ => Language Integrated Query
        }
    }
}
