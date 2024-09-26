using System;

class Program
{
    static List<(string, int)> GetWords(string message)
    {
        List<(string, int)> groceries = new List<(string, int)>();
        while (true)
        {
            Console.Write(message);
            string word = Console.ReadLine().ToLower();
            if (word == "done")
            {
                break;
            }
            Console.Write("Enter the price: ");
            int price = int.Parse(Console.ReadLine());
            groceries.Add((word, price));
        }
        return groceries;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grocery list. Enter 'done' when done.");
        List<(string, int)> groceryList = GetWords("Enter a grocery item: ");
        Console.WriteLine($"Grocery List ({groceryList.Count()} items)");
        int totalCost = 0;
        foreach ((string item, int price) in groceryList)
        {
            Console.WriteLine($"* {item}: ${price}");
            totalCost += price;
        }
        Console.WriteLine($"The total price is ${totalCost}");
    }
}