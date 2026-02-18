using System;
using System.Collections.Generic;
using System.Linq;

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message) { }
}

public class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base(message) { }
}

public abstract class BankAccount
{
    public long AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal Balance { get; set; }

    public List<string> TransactionHistory { get; } = new List<string>();

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidTransactionException("Deposit must be greater than zero.");

        Balance += amount;
        TransactionHistory.Add($"Deposited: {amount}");
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidTransactionException("Withdraw must be greater than zero.");

        if (amount > Balance)
            throw new InsufficientBalanceException("Insufficient balance.");

        Balance -= amount;
        TransactionHistory.Add($"Withdrawn: {amount}");
    }

    public abstract void CalculateInterest();

    public void Transfer(BankAccount toAccount, decimal amount)
    {
        this.Withdraw(amount);
        toAccount.Deposit(amount);
        TransactionHistory.Add($"Transferred {amount} to {toAccount.AccountNumber}");
    }
}


public class SavingsAccount : BankAccount
{
    public decimal MinimumBalance = 10000;

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < MinimumBalance)
            throw new MinimumBalanceException("Minimum balance must be maintained.");

        base.Withdraw(amount);
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * 0.04m;
        Balance += interest;
        TransactionHistory.Add($"Interest Added: {interest}");
    }
}

public class CurrentAccount : BankAccount
{
    public decimal OverdraftLimit = 20000;

    public override void Withdraw(decimal amount)
    {
        if (Balance + OverdraftLimit < amount)
            throw new InsufficientBalanceException("Overdraft limit exceeded.");

        Balance -= amount;
        TransactionHistory.Add($"Withdrawn: {amount}");
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * 0.02m;
        Balance += interest;
        TransactionHistory.Add($"Interest Added: {interest}");
    }
}

public class LoanAccount : BankAccount
{
    public override void Deposit(decimal amount)
    {
        throw new InvalidTransactionException("Deposit not allowed in Loan Account.");
    }

    public override void Withdraw(decimal amount)
    {
        Balance += amount; // Loan amount increases liability
        TransactionHistory.Add($"Loan Taken: {amount}");
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * 0.08m;
        Balance += interest;
        TransactionHistory.Add($"Loan Interest Added: {interest}");
    }
}

class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();

    static void Main()
    {
        SeedData();

        while (true)
        {
            Console.WriteLine("\n1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Show Reports");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        PerformDeposit();
                        break;
                    case 2:
                        PerformWithdraw();
                        break;
                    case 3:
                        PerformTransfer();
                        break;
                    case 4:
                        ShowReports();
                        break;
                    case 5:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void SeedData()
    {
        accounts.Add(new SavingsAccount { AccountNumber = 1, CustomerName = "Rahul", Balance = 60000 });
        accounts.Add(new CurrentAccount { AccountNumber = 2, CustomerName = "Riya", Balance = 30000 });
        accounts.Add(new LoanAccount { AccountNumber = 3, CustomerName = "Aman", Balance = 100000 });
        accounts.Add(new SavingsAccount { AccountNumber = 4, CustomerName = "Sachin", Balance = 80000 });
    }

    static BankAccount GetAccount(long accNo)
    {
        return accounts.First(a => a.AccountNumber == accNo);
    }

    static void PerformDeposit()
    {
        Console.Write("Account No: ");
        long acc = long.Parse(Console.ReadLine());
        Console.Write("Amount: ");
        decimal amt = decimal.Parse(Console.ReadLine());

        GetAccount(acc).Deposit(amt);
    }

    static void PerformWithdraw()
    {
        Console.Write("Account No: ");
        long acc = long.Parse(Console.ReadLine());
        Console.Write("Amount: ");
        decimal amt = decimal.Parse(Console.ReadLine());

        GetAccount(acc).Withdraw(amt);
    }

    static void PerformTransfer()
    {
        Console.Write("From Account: ");
        long from = long.Parse(Console.ReadLine());
        Console.Write("To Account: ");
        long to = long.Parse(Console.ReadLine());
        Console.Write("Amount: ");
        decimal amt = decimal.Parse(Console.ReadLine());

        GetAccount(from).Transfer(GetAccount(to), amt);
    }

    static void ShowReports()
    {
        Console.WriteLine("\n--- Accounts > 50,000 ---");
        var highBalance = accounts.Where(a => a.Balance > 50000);
        foreach (var acc in highBalance)
            Console.WriteLine(acc.CustomerName);

        Console.WriteLine("\nTotal Bank Balance:");
        Console.WriteLine(accounts.Sum(a => a.Balance));

        Console.WriteLine("\nTop 3 Highest Balance:");
        var top3 = accounts.OrderByDescending(a => a.Balance).Take(3);
        foreach (var acc in top3)
            Console.WriteLine(acc.CustomerName + " - " + acc.Balance);

        Console.WriteLine("\nGrouped By Type:");
        var grouped = accounts.GroupBy(a => a.GetType().Name);
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var acc in group)
                Console.WriteLine("  " + acc.CustomerName);
        }

        Console.WriteLine("\nCustomers starting with R:");
        var rCustomers = accounts.Where(a => a.CustomerName.StartsWith("R"));
        foreach (var acc in rCustomers)
            Console.WriteLine(acc.CustomerName);
    }
}
