//принцип розділення інтерфейсу
using System;

interface IPricable
{
    void SetPrice(double price);
}

interface IDiscountable
{
    void ApplyDiscount(string discount);
}

interface IPromocodable
{
    void ApplyPromocode(string promocode);
}

interface IColorable
{
    void SetColor(byte color);
}

interface ISizable
{
    void SetSize(byte size);
}

class Book : IPricable, IDiscountable
{
    private double price;

    public void SetPrice(double price)
    {
        this.price = price;
        Console.WriteLine($"Price for the book set to: {price}");
    }

    public void ApplyDiscount(string discount)
    {
        Console.WriteLine($"Discount '{discount}' applied to the book.");
    }
}

class Outerwear : IPricable, IDiscountable, IColorable, ISizable
{
    private double price;
    private byte color;
    private byte size;

    public void SetPrice(double price)
    {
        this.price = price;
        Console.WriteLine($"Price for the outerwear set to: {price}");
    }

    public void ApplyDiscount(string discount)
    {
        Console.WriteLine($"Discount '{discount}' applied to the outerwear.");
    }

    public void SetColor(byte color)
    {
        this.color = color;
        Console.WriteLine($"Color for the outerwear set to: {color}");
    }

    public void SetSize(byte size)
    {
        this.size = size;
        Console.WriteLine($"Size for the outerwear set to: {size}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();
        book.SetPrice(25.99);
        book.ApplyDiscount("10%OFF");

        Outerwear jacket = new Outerwear();
        jacket.SetPrice(99.99);
        jacket.ApplyDiscount("SUMMER25");
        jacket.SetColor(1);
        jacket.SetSize(42);
    }
}
