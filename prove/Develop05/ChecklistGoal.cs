public class ChecklistGoal : Goal
{
    private int _oneStepValue;
    private int _timesToComplete;
    private int _timesCompleted;

    public ChecklistGoal(string n, string d, int p, int o, int ttc) : base(n, d, p)
    {
        _oneStepValue = o;
        _timesToComplete = ttc;
        _timesCompleted = 0;
    }
    public ChecklistGoal(string n, string d, int p, int o, int ttc, int tc) : base(n, d, p)
    {
        _oneStepValue = o;
        _timesToComplete = ttc;
        _timesCompleted = tc;
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"You have completed {_timesCompleted} / {_timesToComplete} goals.");
    }
    public override int CompleteGoal()
    {
        int total = 0;
        total += _oneStepValue;
        _timesCompleted += 1;
        if (_timesCompleted == _timesToComplete)
        {
            total += _pointValue;
        }
        return total;
    }
    
    public override string GetStringRepresentation()
    {
        string result = "ChecklistGoal:";
        result += base._name + '|' + base._description + '|' + base._pointValue;
        result += '|' + _oneStepValue + '|' + _timesCompleted + '|' + _timesToComplete;
        return result;
    }
}