using System;
using System.Reflection;

class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        var type = typeof(Calculator);
        var method = type.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance);

        var instance = Activator.CreateInstance(type);
        var result = method.Invoke(instance, new object[] { 3, 5 });

        Console.WriteLine(result);
    }
}