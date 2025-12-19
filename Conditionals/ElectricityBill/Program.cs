class Program
{
    public static void Main()
    {
        // Input units consumed
        Console.Write("Enter units consumed: ");
        int units = int.Parse(Console.ReadLine());
        
        double bill = CalculateBill(units);
        Console.WriteLine($"Total Bill: Rs. {bill:F2}");
    }
    
    static double CalculateBill(int units)
    {
        double amount = 0;
        
        if (units <= 199)
        {
            amount = units * 1.20;
        }
        else if (units <= 400)
        {
            amount = (199 * 1.20) + ((units - 199) * 1.50);
        }
        else if (units <= 600)
        {
            amount = (199 * 1.20) + (201 * 1.50) + ((units - 400) * 1.80);
        }
        else
        {
            amount = (199 * 1.20) + (201 * 1.50) + (200 * 1.80) + ((units - 600) * 2.00);
        }

        if (amount > 400)
        {
            amount += amount * 0.15;
        }

        return amount;
    }
}