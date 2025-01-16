namespace OCPApp;

public class Program
{
    public static void Main()
    {
        Rectangle rectangle = new(12, 3);
        Circle circle = new(12);
        Triangle triangle = new(12, 3);

        Console.WriteLine(rectangle.CalculateArea());
        Console.WriteLine(circle.CalculateArea());
        Console.WriteLine(triangle.CalculateArea());

        AreaCalculator areaCalculator = new AreaCalculator();
        Console.WriteLine(areaCalculator.CalculateTotalArea([rectangle, circle, triangle]));


    }
}
