using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string keepPlaying;
        do {
            int magicNumber = randomGenerator.Next(1, 100);
            int response;
            int timesGuessed = 0;
            do {
                Console.Write("Guess my number! ");
                response = int.Parse(Console.ReadLine());
                if (response < magicNumber) {
                    Console.WriteLine("Higher!");
                }
                else if (response > magicNumber) {
                    Console.WriteLine("Lower!");
                }
                timesGuessed ++;
            } while (response != magicNumber);
            Console.WriteLine($"You got it in {timesGuessed} guesses!");
            Console.Write("Do you want to keep playing? (y/n) ");
            keepPlaying = Console.ReadLine();
        } while (keepPlaying == "y");
    }
}