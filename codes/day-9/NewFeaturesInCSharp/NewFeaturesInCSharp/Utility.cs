namespace NewFeaturesInCSharp.Utilities
{
    //static class (2.0)
    static class Utility
    {
        public static void PrintMenu()
        {
            Console.WriteLine("menu");
        }
        public static int GetChoice()
        {
            Console.Write("enter a choice: ");
            return int.Parse(Console.ReadLine() ?? "1");
        }
    }
}
