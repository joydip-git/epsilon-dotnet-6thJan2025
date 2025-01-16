using System.Runtime.Intrinsics.Arm;

namespace OCPApp;

public class Circle : IShape
{
    double radius;

    public Circle()
    {

    }
    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double Radius { get => radius; set => radius = value; }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

}
