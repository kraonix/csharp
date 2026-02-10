using System;
using System.Reflection;

public static class ObjectHelper
{
    public static void PrintKeyValue(object obj)
    {
        if (obj == null)
        {
            Console.WriteLine("Object is null");
            return;
        }

        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            object value = property.GetValue(obj);
            Console.WriteLine($"{property.Name}={value ?? "null"}");
        }
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main()
    {
        var product = new Product
        {
            Id = 101,
            Name = "Keyboard",
            Price = 1500
        };

        ObjectHelper.PrintKeyValue(product);
    }
}
