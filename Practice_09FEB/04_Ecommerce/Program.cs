using System;

public abstract class DiscountPolicy
{
    public abstract double GetFinalAmount(double amount);
}

public class Customer : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        if (amount >= 5000)
        {
            return amount - (amount * 0.10);
        }
        else
        {
            return amount - (amount * 0.05);
        }
    }
}

public class MemberCustomer : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        if (amount >= 2000)
        {
            return amount - 200;
        }
        return amount;
    }
}

public class Program
{
    public static void Main()
    {
        double purchaseAmount = 2000;

        DiscountPolicy normalCustomer = new Customer();
        DiscountPolicy memberCustomer = new MemberCustomer();

        Console.WriteLine($"Original Amount: {purchaseAmount}");

        Console.WriteLine($"Customer Final Amount: {normalCustomer.GetFinalAmount(purchaseAmount)}");

        Console.WriteLine($"Member Customer Final Amount: {memberCustomer.GetFinalAmount(purchaseAmount)}");
    }
}
