namespace OCPApp;

public class Rectangle : IShape
{
    double height;
    double width;

    public Rectangle()
    {

    }
    public Rectangle(double height, double width)
    {
        this.height = height;
        this.width = width;
    }

    public double Height { get => height; set => height = value; }
    public double Width { get => width; set => width = value; }

    public double CalculateArea()
    {
        return height * width;
    }

}
