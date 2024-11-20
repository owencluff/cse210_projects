public class User
{
    private string _name;
    private int _pointsTotal;
    private List<Goal> _goals;

    public User(string n)
    {
        _name = n;
        _pointsTotal = 0;
        _goals  = [];
    }
    public User(string n, List<Goal> g) : this(n)
    {
        _goals = g;
    }

    public string GetName()
    {
        return _name;
    }
    
    public void AddPoints(int points)
    {
        _pointsTotal += points;
    }

    public void SetGoal(string type)
    /*
    takes user input of the type of goal that needs to be set
    prompts for each attribute of the needed goal and creates a new object
    adds the goal to the end of the list of goals
    */
    {
        Console.Write("Enter the goal's name: ");
        string name = Console.ReadLine();
        Console.Write("Enter a brief description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("How many points should it be worth: ");
        int points = Convert.ToInt32(Console.ReadLine());
        if (type == "1")
        {
            SimpleGoal g = new SimpleGoal(name, description, points);
            _goals.Add(g);
            Console.WriteLine("\nYou have set a new simple goal:");
            g.DisplayGoal();
        }
        else if (type == "2")
        {
            EternalGoal g = new EternalGoal(name, description, points);
            _goals.Add(g);
            Console.WriteLine("\nYou have set a new eternal goal:");
            g.DisplayGoal();
        }
        else if (type == "3")
        {
            Console.Write("How many points should one step be worth: ");
            int oneS = Convert.ToInt32(Console.ReadLine());
            Console.Write("How many steps are there: ");
            int steps = Convert.ToInt32(Console.ReadLine());
            ChecklistGoal g = new ChecklistGoal(name, description, points, oneS, steps);
            _goals.Add(g);
            Console.WriteLine("\nYou have set a new checklist goal:");
            g.DisplayGoal();
        }
        else
        {
            throw new Exception("Unrecognized goal type");
            //catches the situation where the input type is not supported
        }
    }

    public void GetGoalNames()
    {
        foreach (Goal g in _goals)
        {
            Console.WriteLine("- " + g.GetName());
        }
    }
    public (Goal, int) FindGoal(string name)
    //Returns a tuple of the goal and its place in the list for easy storage
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
        //throws an exception if the name of the goal is not in the list of goals
    }
    public void ReplaceGoal(Goal g, int i)
    //Replaces the goal at position i with the updated goal g
    {
        _goals[i] = g;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Welcome, {_name}!");
        Console.WriteLine($"Total Points: {_pointsTotal}");
    }
    public void DisplayGoals()
    {
        foreach (Goal g in _goals)
        {
            g.DisplayGoal();
        }
    }
    
    /*
    Goals are stored one per line in a text file
    Each goal is formatted like this:
    SimpleGoal:name|description|pointvalue|iscompleted
    EternalGoal:name|description|pointvalue|timescompleted
    ChecklistGoal:name|description|pointvalue|timescompleted|timestocomplete

    this checks what type of goal each stored goal is, then
    splits each string and creates a new instance of the 
    appriopriate class and stores it in a list.
    */
    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Points:{_pointsTotal}");
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
            if (bits[0] == "Points")
            {
                _pointsTotal = Convert.ToInt32(info[0]);
            }
            if (bits[0] == "SimpleGoal")
            {
                string n = info[0];
                string d = info[1];
                int p = Convert.ToInt32(info[2]);
                bool c = Convert.ToBoolean(info[3]);
                SimpleGoal g = new SimpleGoal(n, d, p, c);
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