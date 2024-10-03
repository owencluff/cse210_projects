public class Box
{
    public double _height = 0;
    public double _width = 0;
    public double _length = 0;
    public string _units = "";

    public string Describe()
    {
        return $"Box {_length}x{_width}x{_height} {_units}";
    }
    public double Volume()
    {
        return _length * _width * _height;
    }
    
}