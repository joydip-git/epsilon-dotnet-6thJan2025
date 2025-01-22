namespace ThreadingDemo
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine($"In Main Method. Thread => {Thread.CurrentThread.ManagedThreadId}");

            //thread for for Run Method
            //ThreadStart runDelegate = new(Run);
            //Thread runThread = new(runDelegate);

            //or shortcut
            Thread runThread = new(Run);

            //thread for for RunAnother Method
            //ParameterizedThreadStart runAnotherDelegate = new(RunAnother);
            //Thread runAnotherThread = new(runAnotherDelegate);

            //or shortcut
            Thread runAnotherThread = new(RunAnother);

            //Run();
            //RunAnother(5);

            runThread.Start();
            runThread.Join();

            runAnotherThread.Start(5);
            runAnotherThread.Join();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main: {i + 1}");
            }
        }
        static void Run()
        {
            Console.WriteLine($"In Run Method. Thread => {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(1000);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Run: {i + 1}");
            }
        }
        static void RunAnother(object? obj)
        {
            Console.WriteLine($"In Run Another Method. Thread => {Thread.CurrentThread.ManagedThreadId}");
            int count = (int)obj;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"RunAnother: {i + 1}");
            }
        }
    }
}
