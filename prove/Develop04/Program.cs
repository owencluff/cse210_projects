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
            if (input == "1")
            {
                string name = "Breathing";
                string description = "This activity will help you guide your breathing.";
                Console.Write("How long would you like to do this activity? ");
                int duration = Convert.ToInt32(Console.ReadLine());
                Breathing breathe = new Breathing(name, description, duration);
                breathe.Breathe();
            }
            else if (input == "2")
            {
                string name = "Reflection";
                string description = @"This activity will help you reflect on 
                times in your life where you showed resilience.";
                Console.Write("How long would you like to do this activity? ");
                int duration = Convert.ToInt32(Console.ReadLine());
                Reflection reflect = new Reflection(name, description, duration);
                reflect.Reflect();
            }
            else if (input == "3")
            {
                string name = "Ennumeration";
                string description = @"This activity will help you reflect on 
                good things in your life.";
                Console.Write("How long would you like to do this activity? ");
                int duration = Convert.ToInt32(Console.ReadLine());
                Ennumeration ennum = new Ennumeration(name, description, duration);
                ennum.Ennumerate();
            }
            else if (input == "4")
            {
                break;
            }
        }
    }
}