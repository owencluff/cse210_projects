using System;

class Program
{   
    static void Main(string[] args)
    {
        string input;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness program!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("    1) Breathing Activity");
            Console.WriteLine("    2) Reflection Activity");
            Console.WriteLine("    3) Ennumeration Activity");
            Console.WriteLine("    4) Quit Program");
            Console.WriteLine("\n(1/2/3/4)");
            Console.Write(">| ");
            input = Console.ReadLine();
            
            /*Pattern for the input:
            -Clear the console
            -Set the name and description
            -Ask for a duration
            -Create an instance of a class with the chosen attributes
            -Run the activity*/

            if (input == "1")
            {
                Console.Clear();
                string name = "Breathing";
                //Is there a better way of setting the description?
                //I don't want to have my strings be too long.
                string description = "This activity will help you relax by " + 
                "guiding your breathing in and out slowly. Clear your mind" + 
                " and focus on your breathing.";
                Console.WriteLine("How long would you like to do this activity?");
                Console.Write("Enter the number of seconds: ");
                int duration = Convert.ToInt32(Console.ReadLine());
                Breathing breathe = new Breathing(name, description, duration);
                breathe.Breathe();
            }
            else if (input == "2")
            {
                Console.Clear();
                string name = "Reflection";
                string description = "This activity will help you reflect on " +
                "times in your life where you showed strength resilience. " + 
                "This will help you recognize the power you have in your life";
                Console.WriteLine("How long would you like to do this activity?");
                Console.Write("Enter the number of seconds: ");
                int duration = Convert.ToInt32(Console.ReadLine());
                Reflection reflect = new Reflection(name, description, duration);
                reflect.Reflect();
            }
            else if (input == "3")
            {
                Console.Clear();
                string name = "Ennumeration";
                string description = "This activity will help you reflect on " + 
                "the good things in your life by having you list as many " +
                "things as you can in a certain area.";
                Console.WriteLine("How long would you like to do this activity?");
                Console.Write("Enter the number of Seconds: ");
                int duration = Convert.ToInt32(Console.ReadLine());
                Ennumeration ennum = new Ennumeration(name, description, duration);
                ennum.Ennumerate();
            }
            else if (input == "4")
            {
                Console.Clear();
                Console.WriteLine("Thanks for using the Mindfulness Program!");
                Thread.Sleep(5000);
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}