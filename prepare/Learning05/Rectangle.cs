public class Rectangle : Shape
{
    private double _width;
    private double _height;

    public Rectangle(double w, double h, string c) : base(c)
    {
        _width = w;
        _height = h;
    }

    public override double GetArea()
    {
        return _width * _height;
    }
}