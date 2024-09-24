using System;

class Program
{
    static void Main(string[] args)
    {
        List<float> numbers = new List<float>();
        Console.WriteLine("Enter a list of numbers, enter 0 when finished.");
        float number = 1;
        float total = 0;
        while (number != 0)
        {
            Console.Write("Enter a number: ");
            number = float.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        }
        float largest = 0;
        foreach (float item in numbers){
            total += item;
            if (item > largest){
                largest = item;
            }
        }
        float newCount = numbers.Count;
        float average = total / newCount;
        Console.WriteLine($"{numbers.Count}");
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}