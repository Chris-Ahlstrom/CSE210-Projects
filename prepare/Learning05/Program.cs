using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square one = new Square(12, "Blue");
        shapes.Add(one);
        Rectangle two = new Rectangle(8, 14, "Red");
        shapes.Add(two);
        Circle three = new Circle(9, "Green");
        shapes.Add(three);
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} - Area: {shape.GetArea()}");
        }
    }
}