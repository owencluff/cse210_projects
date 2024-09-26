using System;

class Program
{
    static List<string> getWords()
    {
        List<string> words = new List<string>();
        while (true)
        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();
            if (word == string.Empty)
            {
                break;
            }
            words.Add(word);
        }
        return words;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of words. Enter a blank line when finished.");
        List<string> words = new List<string>();
        words = getWords();
        Console.WriteLine($"There are {words.Count} words in this list.");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}