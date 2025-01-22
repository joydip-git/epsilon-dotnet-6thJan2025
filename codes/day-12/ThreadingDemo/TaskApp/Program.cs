namespace TaskApp
{
    internal class Program
    {
        //static void Main()
        static async Task Main()
        {
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("\n");
            try
            {
                double result = await PerformNumberTask();
                Console.WriteLine($"Task Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            //Task<double> numberTask = PerformNumberTask();

            //Result property is a blocking property => it blocks the remaining code in this scope until and unless the Task is over
            //Console.WriteLine($"Task Result: {numberTask.Result}");

            //Task<double> numberTask = PerformNumberTask();
            //if (numberTask.Status == TaskStatus.RanToCompletion)
            //{
            //    Console.WriteLine($"Task Result: {numberTask.Result}");
            //}
            //else
            //    Console.WriteLine(numberTask.Status);

            //bool isOver = numberTask.Wait(1500);
            //if (isOver)
            //{
            //    Console.WriteLine($"Task Result: {numberTask.Result}");
            //}
            //else
            //    Console.WriteLine("task is not over yet...");
            Console.WriteLine("This is the last line of Main Method...");
        }
        static Task<double> PerformNumberTask()
        {
            Task<double> numberTask = Task.Run(
                () =>
                {
                    Console.WriteLine($"Task Thread: {Thread.CurrentThread.ManagedThreadId}");
                    int[] ints = [1, 2, 3, 4];
                    Thread.Sleep(2000);
                    return ints.Average();
                }
                );
            return numberTask;
        }
    }
}
