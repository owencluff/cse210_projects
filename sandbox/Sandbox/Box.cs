public class Box
{
    private double _height = 0;
    private double _width = 0;
    private double _length = 0;
    private string _units = "";

    public Box(double height, double width, double length, string units)
    {
        _height = height;
        _width = width;
        _length = length;
        _units = units;
    }
    public Box(double height, double width, double length)
    {
        _height = height;
        _width = width;
        _length = length;
        _units = "in";
    }

    public void Describe()
    {
        Console.WriteLine($"Box {_length}x{_width}x{_height} {_units}");
    }
    public void Volume()
    {
        Console.WriteLine($"Volume = {_length * _width * _height} {_units}^3");
    }
    
}