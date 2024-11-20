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
        if (_isCompleted)
        {
            Console.WriteLine("You have completed this goal.");
        }
        else
        {
            Console.WriteLine("You have not completed this goal.");
        }
    }

    public override int CompleteGoal()
    {
        _isCompleted = true;
        return _pointValue;
    }

    public override string GetStringRepresentation()
    {
        string result = "SimpleGoal:";
        result += base._name + '|' + base._description + '|' + base._pointValue;
        result += '|' + Convert.ToString(_isCompleted);
        return result;
    }
}