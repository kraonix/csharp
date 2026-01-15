using System;

public class EcommerceShop
{
    public string? UserName { get; set; }
    public double WalletBalance { get; set; }
    public double TotalPurchaseAmount { get; set; }
}

public class Insufficient : Exception
{
    public Insufficient(string msg) : base(msg)
    {
    }
}

public class Program
{
    public static EcommerceShop MakePayment(string name, double balance, double amount)
    {
        EcommerceShop e = new EcommerceShop
        {
            UserName = name,
            WalletBalance = balance,
            TotalPurchaseAmount = amount
        };

        if (e.TotalPurchaseAmount > e.WalletBalance)
        {
            throw new Insufficient("Insufficient Balance in Digital Wallet");
        }

        // Deduct amount after successful payment
        e.WalletBalance -= e.TotalPurchaseAmount;

        return e;
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Digital Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter Total Purchasable Amount: ");
            double amount = double.Parse(Console.ReadLine());

            EcommerceShop e = MakePayment(name, balance, amount);

            Console.WriteLine("\nPayment Successful!");
            Console.WriteLine($"Remaining Balance: {e.WalletBalance}");
        }
        catch (Insufficient ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format.");
        }
    }
}
