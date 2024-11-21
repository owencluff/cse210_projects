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
        Console.WriteLine($">>{_timesCompleted}/{_timesToComplete} times completed");
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
        result += base._name + '|' + base._description + '|';
        result += base._pointValue.ToString() + '|' + _oneStepValue.ToString();
        result += '|' + _timesCompleted.ToString() + '|' + _timesToComplete.ToString();
        return result;
    }
}