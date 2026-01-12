class Source
{
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    public double Add(double a, double b, double c)
    {
        return a + b + c;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Source s = new Source();
        int a = s.Add(10, 20, 30);
        double b = s.Add(9.9, 8.34, 0.11);

        Console.WriteLine(a + " " + b);
    }
}