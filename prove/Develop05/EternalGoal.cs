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
        Console.WriteLine($"You have completed this goal {_timesCompleted} times.");
    }
    public override int CompleteGoal()
    {
        _timesCompleted += 1;
        return _pointValue;
    }

    public override string GetStringRepresentation()
    {
        string result = "EternalGoal:";
        result += base._name + '|' + base._description + '|';
        result += base._pointValue.ToString() + '|' + _timesCompleted.ToString();
        Console.WriteLine(result);
        return result;
    }
}