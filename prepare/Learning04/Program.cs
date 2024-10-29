using System;

class Program
{
    static void Main(string[] args)
    {
        Math homework1 = new Math("John Smith", "Algebra", "5.6", "14-35");
        History homework2 = new History("John Smith", "Revolution", "How the UK Lost the War");
        Console.WriteLine(homework1.GetSummary());
        Console.WriteLine(homework1.GetHomeworkList());
        Console.WriteLine(homework2.GetSummary());
        Console.WriteLine(homework2.GetWritingInfo());
    }
}