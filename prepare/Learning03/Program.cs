using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(3);
        Fraction f3 = new Fraction(2, 5);
        f1.SetTop(4);
        f1.SetBottom(67);
        Console.WriteLine(f1.GetBottom());
        Console.WriteLine(f1.GetTop());
        Console.WriteLine(f3.GetDecimalValue());
        Console.WriteLine(f2.GetFractionString());
    }
}