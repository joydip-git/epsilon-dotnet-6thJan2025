namespace GenericDemo
{
    interface ICalculation<T> where T : struct
    {
        void Add(T x, T y);
        void Subtract(int x, int y);
    }
}
