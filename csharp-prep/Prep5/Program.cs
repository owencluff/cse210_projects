using System;
using System.Collections.Specialized;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }
    static int SquareNumber(int num)
    {
        int NewNum = num * num;
        return NewNum;
    }
    static void DisplayResult(int num, string name)
    {
        Console.WriteLine($"{name}, the square of your number is {num}");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int NewNum = SquareNumber(num);
        DisplayResult(NewNum, name);
    }
}