namespace CalculatorLib;

public class Calculator
{
    public int Add(int a, int b)
    {
        checked
        {
            return a + b; // overflow-safe
        }
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");

        return a / b;
    }

    public double SquareRoot(double value)
    {
        if (value < 0)
            throw new ArgumentException("Cannot take square root of a negative number");

        return Math.Sqrt(value);
    }

    public int ParseAndAdd(string a, string b)
    {
        int x = int.Parse(a);
        int y = int.Parse(b);
        return Add(x, y);
    }
}
