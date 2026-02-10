using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Property)]
public class MaxLengthAttribute : Attribute
{
    public int Length { get; }

    public MaxLengthAttribute(int length)
    {
        Length = length;
    }
}

public class Product
{
    public int Id { get; set; }

    [MaxLength(10)]
    public required string Name { get; set; }

    [MaxLength(10)]
    public required string Category { get; set; }
}

public static class Validator
{
    public static void Validate(object obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        var properties = obj.GetType().GetProperties();

        foreach (var prop in properties)
        {
            var attribute = prop.GetCustomAttribute<MaxLengthAttribute>();

            if (attribute != null && prop.PropertyType == typeof(string))
            {
                string? value = prop.GetValue(obj) as string;

                if (value != null && value.Length > attribute.Length)
                {
                    throw new ArgumentException(
                        $"Property '{prop.Name}' exceeds max length of {attribute.Length}."
                    );
                }
            }
        }
    }
}


class Program
{
    static void Main()
    {
        var product = new Product
        {
            Id = 1,
            Name = "SuperLongProductName", // > 10 chars
            Category = "Electronics"
        };

        Validator.Validate(product);
    }
}
