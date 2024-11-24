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
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Set a Goal\n2) Record a Goal\n3) View Your Goals"+
            "\n4) Save Goals\n5) Load Goals\n6) Quit");
            Console.Write("\n(1/2/3/4/5/6)> ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                string response;
                do
                {
                    Console.Clear();
                    Console.WriteLine("What type of goal would you like to set?");
                    Console.Write("1) Simple\n2) Eternal\n3) Checklist");
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
                    Console.Write("\nPress any key to continue: ");
                    response = Console.ReadLine();
                }while(response == null);
            }
            else if (input == "2")
            {
                string response;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Your current goals are: ");
                    user1.GetGoalNames();
                    Console.Write("What goal would you like to record? ");
                    try
                    {
                        string choice = Console.ReadLine();
                        var g = user1.FindGoal(choice);
                        user1.AddPoints(g.Item1.CompleteGoal());
                        user1.ReplaceGoal(g.Item1, g.Item2);
                        Console.WriteLine("Goal completed: ");
                        g.Item1.DisplayGoal();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.Write("\nPress any key to continue");
                    response = Console.ReadLine();
                }while(response == null);
            }
            else if (input == "3")
            {
                string response;
                do
                {
                    Console.Clear();
                    user1.DisplayInfo();
                    user1.DisplayGoals();
                    Console.Write("\nPress any key to continue");
                    response = Console.ReadLine();
                }while(response == null);
            }
            else if (input == "4")
            {
                string response;
                do
                {
                    Console.Clear();
                    Console.Write("Where would you like to save your goals? ");
                    string filename = Console.ReadLine();
                    user1.SaveGoals(filename);
                    Console.Write("\nPress any key to continue");
                    response = Console.ReadLine();
                }while(response == null);
            }
            else if (input == "5")
            {
                string response;
                do
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
                    Console.Write("\nPress any key to continue.");
                    response = Console.ReadLine();
                }while (response == null);
            }
            else if (input == "6")
            {
                Console.WriteLine("Goodbye!");
                Thread.Sleep(1000);
                Console.Clear();
                break;
            }
            else
            {
                string response;
                do
                {
                    Console.Write("Unexpected input");
                    response = Console.ReadLine();
                }while(response == null);
            }
        }
    }
}