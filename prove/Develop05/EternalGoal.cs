using System.Xml.XPath;

public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string n, string d, int p) : base(n, d, p)
    {
        _timesCompleted = 0;
    }
    public EternalGoal(string n, string d, int p, int t) : base(n, d, p)
    {
        _timesCompleted = t;
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($">>completed {_timesCompleted} times.");
    }
    public override int CompleteGoal()
    {
        _timesCompleted += 1;
        return _pointValue;
    }

    public override string GetStringRepresentation()
    {
        string result = "EternalGoal:" + base.GetStringRepresentation();
        return result + '|' + _timesCompleted;
    }
}