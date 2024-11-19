public class User
{
    private string _name;
    private int _pointsTotal;
    private List<Goal> _goals;

    public User(string n, List<Goal> g)
    {
        _name = n;
        _pointsTotal = 0;
        _goals  = g;
    }
    public User(string n)
    {
        _name = n;
    }

    public string GetName()
    {
        return _name;
    }
    
    public void AddPoints(int points)
    {
        _pointsTotal += points;
    }
    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }
    public void GetGoalNames()
    {
        foreach (Goal g in _goals)
        {
            Console.WriteLine("- " + g.GetName());
        }
    }
    public (Goal, int) FindGoal(string name)
    {
        foreach (Goal g in _goals)
        {
            if (name == g.GetName())
            {
                int index = _goals.IndexOf(g);
                return (g, index);
            }
        }
        throw new Exception("Goal not found");
    }
    public void ReplaceGoal(Goal g, int i)
    {
        _goals[i] = g;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Welcome, {_name}!");
        Console.WriteLine($"Total Points: {_pointsTotal}");
    }
    public void AddPoints(int pointValue)
    {
        _pointsTotal += pointValue;
    }
    public void DisplayGoals()
    {
        foreach (Goal g in _goals)
        {
            g.DisplayGoal();
        }
    }
    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(Goal g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved to {filename}");
    }
    public void LoadGoals(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        List<Goal> goals = new List<Goal>();
        foreach (string line in lines)
        {
            string[] bits = line.Split(':');
            string[] info = bits[1].Split('|');
            if (bits[0] == "SimpleGoal")
            {
                string n = info[0];
                string d = info[1];
                int p = Convert.ToInt32(info[2]);
                SimpleGoal g = new SimpleGoal(n, d, p);
                goals.Add(g);
            }
            if(bits[0] == "EternalGoal")
            {
                string n = info[0];
                string d = info[1];
                int p = Convert.ToInt32(info[2]);
                int t = Convert.ToInt32(info[3]);
                EternalGoal g = new EternalGoal(n, d, p, t);
                goals.Add(g);
            }
            if(bits[0] == "ChecklistGoal")
            {
                string n = info[0];
                string d = info[1];
                int p = Convert.ToInt32(info[2]);
                int tc = Convert.ToInt32(info[3]);
                int ttc = Convert.ToInt32(info[4]);
                ChecklistGoal g = new ChecklistGoal(n, d, p, tc, ttc);
                goals.Add(g);
            }
        }
        _goals = goals;
    }
}