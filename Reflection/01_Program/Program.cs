using System;
using System.Reflection;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
}

class Program
{
    static void Main()
    {
        Type type = typeof(Product);

        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo prop in properties)
        {
            Console.WriteLine($"{prop.PropertyType.Name} {prop.Name}");
        }
    }
}
