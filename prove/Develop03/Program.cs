using System;

class Program
{
    static void MemorizeScripture(Scripture scripture)
    {
        string response;
        do
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("Press enter to redact scripture or type 'quit' to quit");
            response = Console.ReadLine();
            if (response == "" && !scripture.GetFullyRedacted())
            {
                scripture.RedactScripture();
            }
            else
            {
                break;
            }

        } while (response == "");
    }
    static List<Word> GetWords()
    {
        List<Word> keepers = new List<Word>();
        Console.WriteLine("Enter the scripture you would like to memorize!");
        string scripture = Console.ReadLine();
        string[] words = scripture.Split(' ');
        foreach (string word in words)
        {
            Word result = new Word(word);
            keepers.Add(result);
        }
        return keepers;
    }

    static Reference NewReference()
    {
        Console.Write("Does the passage contain multiple verses? (y/n): ");
        string response = Console.ReadLine();
        if (response == "n")
        {
            Console.Write("Enter the book: ");
            string book = Console.ReadLine();
            Console.Write("Enter the chapter: ");
            string chapter = Console.ReadLine();
            Console.Write("Enter the verse: ");
            string verse = Console.ReadLine();
            Reference reference = new Reference(book, chapter, verse);
            return reference;
        }
        else
        {
            Console.Write("Enter the book: ");
            string book = Console.ReadLine();
            Console.Write("Enter the chapter: ");
            string chapter = Console.ReadLine();
            Console.Write("Enter the first verse: ");
            string verseStart = Console.ReadLine();
            Console.Write("Enter the last verse: ");
            string verseEnd = Console.ReadLine();
            Reference reference = new Reference(book, chapter, verseStart, verseEnd);
            return reference;
        }
    }
    static void Main(string[] args)
    {       
        Scripture myScripture = new Scripture();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Scripture memorizing program!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Enter a scripture to memorize");
            Console.WriteLine("2)Memorize a scripture");
            Console.WriteLine("3) Quit");
            string input = Console.ReadLine();
            if (input == "1")
            {
                myScripture = new Scripture(NewReference(), GetWords());
            }
            else if (input == "2")
            {
                MemorizeScripture(myScripture);
            }
            else if (input == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("INVALID INPUT");
            }
        } 
    }
}