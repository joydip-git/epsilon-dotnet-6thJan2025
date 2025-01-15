using CalculationLibrary;

namespace ExceptionHandlingDemo
{
    internal class Program
    {
        static int GetValue()
        {
            Console.Write("enter value: ");
            return int.Parse(Console.ReadLine());
        }

        static void Main()
        {
            int result = -1;
            try
            {
                int first = GetValue();
                int second = GetValue();

                result = Calculation.Divide(first, second);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Exception Class: {ex.GetType().Name}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"Details: {ex.StackTrace}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Exception Class: {ex.GetType().Name}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"Details: {ex.StackTrace}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception Class: {ex.GetType().Name}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"Details: {ex.StackTrace}");
            }
            catch (DivisionArgumentException ex)
            {
                Console.WriteLine($"Exception Class: {ex.GetType().Name}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"Details: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Class: {ex.GetType().Name}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"Details: {ex.StackTrace}");
            }            
            finally
            {
                Console.WriteLine(result == -1 ? "could not divide" : result);
            }
        }
    }
}
