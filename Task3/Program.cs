using System;
abstract class Shape
{
    public string Name { get; set; }

    public abstract int GetArea();

    public void DisplayInfo()
    {
        Console.WriteLine($"{Name}: The area is {GetArea()}");
    }
}

class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override int GetArea()
    {
        return Width * Height;
    }
}

class Square : Shape
{
    public int Side { get; set; }

    public override int GetArea()
    {
        return Side * Side;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape rect = new Rectangle { Name = "Rectangle", Width = 5, Height = 10 };
        rect.DisplayInfo();

        Shape square = new Square { Name = "Square", Side = 5 };
        square.DisplayInfo();

        Console.ReadKey();
    }
}