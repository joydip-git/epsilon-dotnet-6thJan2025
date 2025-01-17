namespace GenericDemo
{
    internal class Program
    {
        //T -> type parameter

        //static void Add<T>(T x, T y) where T : class
        //{

        //}
        //static void Add<TInput>(TInput x, TInput y) where TInput : struct
        //{

        //}
        static void Add<TInput>(TInput x, TInput y) //TInput can be anything
        {

        }
        static void Add<T1, T2>(T1 x, T2 y)
        {

        }
        //static void Add(long x, long y)
        //{
        //    Console.WriteLine(x + y);
        //}
        //static void Add(string x, string y)
        //{
        //    Console.WriteLine(x + y);
        //}
        static void Main()
        {
            //Add<int>(12.34, 13);
            Add<int>(12, 13);
            Add<string>("epsilon", "bangalore");
            Add<double>(12.34, 34.56);

            Add<int, long>(12, 123456789123);
            Add<int, int>(12, 13);

            Calculation<int> calculation = new Calculation<int>();
            calculation.Add(12, 13);

            ICalculation<int> calcContract = calculation;            
            calcContract.Add(12,13);
        }
    }
}
