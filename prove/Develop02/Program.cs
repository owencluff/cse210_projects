using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        Console.WriteLine("Welcome to the journal software!");
        do
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Write a journal entry\n2) Read current journal entries\n3) Save the current journal\n4) Load a saved journal\n5) Quit");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine();
                myJournal.GetEntry();
            }
            else if (input == "2")
            {
                Console.WriteLine();
                myJournal.DisplayJournal();
            }
            else if (input == "3")
            {
                Console.WriteLine();
                Console.Write("Where would you like to save your journal to? ");
                string saveFilename = Console.ReadLine();
                myJournal.SaveJournal(saveFilename);
            }
            else if (input == "4")
            {
                Console.WriteLine();
                Console.Write("What file would you like to load as a journal? ");
                string openFilename = Console.ReadLine();
                Console.WriteLine();
                myJournal.LoadJournal(openFilename);
                Console.WriteLine($"Loaded {openFilename}:");
                myJournal.DisplayJournal();
            }
            else
            {
                break;
            }

        } while (true);
    }
}