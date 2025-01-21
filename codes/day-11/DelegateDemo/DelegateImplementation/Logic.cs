namespace DelegateImplementation
{
    public delegate bool NumericalLogicInvoker(int x);
    public delegate bool StringLogicInvoker(string value);

    //delegate bool Predicate<in T>(T obj);
    public delegate bool LogicInvoker<in T>(T value);

    // delegate TResult Func<in T, out TResult>(T obj);
    //public delegate TResult LogicInvoker<in T, out TResult>(T value);

    public class Logic
    {
        //method body expression syntax
        public bool IsEven(int num) => num % 2 == 0;
        public static bool IsOdd(int num) => num % 2 != 0;
        public bool IsGraeter(int num) => num > 4;

        //read-only property
        //public string Name => "name";
    }
}
