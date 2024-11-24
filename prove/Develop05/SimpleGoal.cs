public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string n, string d, int p) : base(n, d, p)
    {
        _isCompleted = false;
    }
    public SimpleGoal(string n, string d, int p, bool c) : base(n, d, p)
    {
        _isCompleted = c;
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($">>has been completed: {_isCompleted}");
    }

    public override int CompleteGoal()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            return _pointValue;
        }
        else
        {
            Console.WriteLine("This goal has already been completed");
            return 0;
        }
    }

    public override string GetStringRepresentation()
    {
        string result = "SimpleGoal:" + base.GetStringRepresentation();
        return result + '|' + _isCompleted.ToString();
    }
}