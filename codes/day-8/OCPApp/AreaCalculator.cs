namespace OCPApp;

public class AreaCalculator
{

    // public double CalculateTotalArea(Rectangle[] rectangles)
    // {
    //     double area = 0;
    //     foreach (Rectangle rect in rectangles)
    //     {
    //         area += rect.Width * rect.Height;
    //     }
    //     return area;
    // }
    // public double CalculateTotalArea(object[] shapes)
    // {
    //     double area = 0;
    //     foreach (object shape in shapes)
    //     {
    //         if (shape is Rectangle)
    //         {
    //             Rectangle rectangle = (Rectangle)shape;
    //             area += rectangle.Width * rectangle.Height;
    //         }
    //         if (shape is Circle)
    //         {
    //             Circle circle = (Circle)shape;
    //             area += circle.Radius * circle.Radius * Math.PI;
    //         }
    //     }
    //     return area;
    // }
    public double CalculateTotalArea(IShape[] shapes)
    {
        double totalArea = 0;
        foreach (IShape shape in shapes)
        {
            totalArea += shape.CalculateArea();
        }
        return totalArea;
    }
}
