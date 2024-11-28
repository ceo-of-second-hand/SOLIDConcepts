//порушено принцип "single responsibility"
using System;
using System.Collections.Generic;

class Item
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Item(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

class Order
{
    private List<Item> itemList = new List<Item>();

    public void AddItem(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }
        itemList.Add(item);
    }

    public void DeleteItem(Item item)
    {
        if (item == null || !itemList.Contains(item))
        {
            throw new ArgumentException("Item not found in the order");
        }
        itemList.Remove(item);
    }

    public int GetItemCount()
    {
        return itemList.Count;
    }

    public List<Item> GetItems()
    {
        return new List<Item>(itemList);
    }

    public decimal CalculateTotalSum()
    {
        decimal total = 0;
        foreach (var item in itemList)
        {
            total += item.Price;
        }
        return total;
    }
}

class OrderSaver
{
    public void Save(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }
        Console.WriteLine("Order saved");
    }

    public Order Load()
    {
        Console.WriteLine("Order loaded");
        return new Order();
    }

    public void Update(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }
        Console.WriteLine("Order updated");
    }

    public void Delete(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }
        Console.WriteLine("Order deleted");
    }
}

class OrderPrinter
{
    public void PrintOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }
        Console.WriteLine("Order Details:");
        foreach (var item in order.GetItems())
        {
            Console.WriteLine($"- {item.Name}: {item.Price:C}");
        }
        Console.WriteLine($"Total: {order.CalculateTotalSum():C}");
    }

    public void ShowOrder(Order order)
    {
        Console.WriteLine("Showing order");
    }
}

class OrderChanger
{
    public void ChangeItemPrice(Order order, Item item, decimal newPrice)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }
        if (item == null || !order.GetItems().Contains(item))
        {
            throw new ArgumentException("Item not found in the order");
        }
        item.Price = newPrice;
        Console.WriteLine($"Item {item.Name} price updated to {newPrice:C}");
    }

    public void ChangeItemName(Order order, Item item, string newName)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }
        if (item == null || !order.GetItems().Contains(item))
        {
            throw new ArgumentException("Item not found in the order");
        }
        item.Name = newName;
        Console.WriteLine($"Item name updated to {newName}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();
        OrderSaver orderSaver = new OrderSaver();
        OrderPrinter orderPrinter = new OrderPrinter();
        OrderChanger orderChanger = new OrderChanger();

        Item item1 = new Item("Laptop", 1000.00m);
        Item item2 = new Item("Mouse", 25.00m);

        order.AddItem(item1);
        order.AddItem(item2);

        orderPrinter.PrintOrder(order);

        orderChanger.ChangeItemPrice(order, item1, 950.00m);
        orderChanger.ChangeItemName(order, item2, "Gaming Mouse");

        orderPrinter.PrintOrder(order);

        orderSaver.Save(order);
        orderSaver.Load();

        Console.ReadKey();
    }
}