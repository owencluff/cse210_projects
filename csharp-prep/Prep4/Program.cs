using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, enter 0 when finished.");
        int number = 1;
        int total = 0;
        while (number != 0)
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        }
        int largest = 0;
        foreach (int item in numbers){
            total += item;
            if (item > largest){
                largest = item;
            }
        }
        float newTotal = total;
        float newCount = numbers.Count;
        float average = newTotal / newCount;
        ;
        Console.WriteLine($"{numbers.Count}");
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}