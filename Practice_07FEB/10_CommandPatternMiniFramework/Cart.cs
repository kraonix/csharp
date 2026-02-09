using System;
using System.Collections.Generic;

public class Cart
{
    private List<string> _items = new();
    private decimal _discountPercentage = 0;

    public void AddItem(string item)
    {
        _items.Add(item);
    }

    public void RemoveItem(string item)
    {
        _items.Remove(item);
    }

    public void ApplyDiscount(decimal percentage)
    {
        _discountPercentage = percentage;
    }

    public void RemoveDiscount()
    {
        _discountPercentage = 0;
    }

    public void Print()
    {
        Console.WriteLine("Cart Items:");
        foreach (var item in _items)
            Console.WriteLine($" - {item}");

        Console.WriteLine($"Discount: {_discountPercentage}%");
        Console.WriteLine("----------------------------");
    }
}