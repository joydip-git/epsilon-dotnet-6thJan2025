namespace GenericDemo
{
    class Calculation<T> : ICalculation<T> where T : struct
    {
        public void Add(T x, T y)
        {

        }
        public void Subtract(int x, int y) { Console.WriteLine(x - y); }
    }
}
