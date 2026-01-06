// Delegate declaration
public delegate int DelegateMethod(int a, int b);

public class Example
{
    // Delegate variable at class level
    public DelegateMethod DelVar;

    public Example()
    {
        // Assign method to delegate
        DelVar = AddMethod1;
    }

    private int AddMethod1(int a, int b)
    {
        return a + b + 10;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Example e1 = new Example();

        int temp = e1.DelVar(10, 20);

        Console.WriteLine(temp);
    }
}