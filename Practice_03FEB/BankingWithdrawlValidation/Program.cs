using System;

class BankAccount
{
    static void Main()
    {
        int balance = 10000;

        try
        {
            Console.Write("Enter withdrawal amount: ");
            int amount = int.Parse(Console.ReadLine());

            if (amount <= 0)
            {
                throw new Exception("Withdrawal amount must be greater than zero.");
            }

            if (amount > balance)
            {
                throw new Exception("Insufficient balance.");
            }

            balance -= amount;
            Console.WriteLine($"Withdrawal successful. Remaining balance: Rs. {balance}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter numbers only.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction logged.");
        }
    }
}