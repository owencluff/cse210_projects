public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string n, string d, int p) : base(n, d, p)
    {
        _isCompleted = false;
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
    public override string GetStringRepresentation()
    {
        string result = "SimpleGoal:";
        result += base._name + '|' + base._description + '|' + base._pointValue;
        return result;
    }
    public override int CompleteGoal()
    {
        _isCompleted = true;
        return _pointValue;
    }
}