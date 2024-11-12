using System;

class Program
{
    static void Main(string[] args)
    {
        Square shape1 = new Square(15, "red");
        Rectangle shape2 = new Rectangle(15, 13, "blue");
        Circle shape3 = new Circle(15, "green");
        List<Shape> shapes = [shape1, shape2, shape3];

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine();
        }
    }
}