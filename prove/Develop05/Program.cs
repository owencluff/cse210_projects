using System;

class Program
{   
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the goal-setting program!");
        Console.Write("What is your name: ");
        string name = Console.ReadLine();
        User user1 = new User(name);
        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Set Goals\n2) Record a Goal\n3) Save Goals\n4) Load Goals\n5) Quit");
            Console.Write("\n(1/2/3/4/5)> ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                Console.WriteLine("What type of goal would you like to set?");
                Console.WriteLine("1) Simple\n2) Eternal\n3) Checklist");
                Console.Write("\n(1/2/3)> ");
                try
                {
                    string choice = Console.ReadLine();
                    user1.SetGoal(choice);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine("Your current goals are: ");
                user1.GetGoalNames();
                Console.Write("What goal would you like to record? ");
                try
                {
                    string choice = Console.ReadLine();
                    var g = user1.FindGoal(choice);
                    g.Item1.CompleteGoal();
                    user1.ReplaceGoal(g.Item1, g.Item2);
                    Console.WriteLine("Goal completed: ");
                    g.Item1.DisplayGoal();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (input == "3")
            {
                Console.Clear();
                Console.Write("Where would you like to save your goals? ");
                string filename = Console.ReadLine();
                user1.SaveGoals(filename);
            }
            else if (input == "4")
            {
                Console.Clear();
                Console.WriteLine($"Loading goals to {user1.GetName()}\n");
                Console.Write("What file would you like to load? ");
                try
                {
                    string filename = Console.ReadLine();
                    user1.LoadGoals(filename);
                    Console.WriteLine($"Goals Loaded to {user1.GetName()}'s list.");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("That file does not exist");
                }
            }
            else if (input == "5")
            {
                Console.WriteLine("Goodbye!");
                Thread.Sleep(1000);
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine("unexpected input");
            }
        }
    }
}