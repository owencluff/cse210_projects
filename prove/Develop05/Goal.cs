using System.Xml.XPath;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _pointValue;

    public Goal(string n, string d, int p)
    {
        _name = n;
        _description = d;
        _pointValue = p;
    }

    public string GetName()
    {
        return _name;
    }
    public virtual void DisplayGoal()
    {
        Console.WriteLine($"{_name}:");
        Console.WriteLine($">>Description: {_description}");
        Console.WriteLine($">>Worth: {_pointValue} points");
    }
    public virtual string GetStringRepresentation()
    {
        return _name + '|' + _description + '|' + _pointValue.ToString();
    }
    public abstract int CompleteGoal();
}