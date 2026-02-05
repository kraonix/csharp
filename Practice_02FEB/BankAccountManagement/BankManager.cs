using System;
using System.Collections.Generic;
using System.Linq;

public class BankManager
{
    private readonly List<Account> _accounts = new();

    // Create Account
    public void CreateAccount(string holder, string type, double initialDeposit)
    {
        var account = new Account
        {
            AccountNumber = Guid.NewGuid().ToString().Substring(0, 8),
            AccountHolder = holder,
            AccountType = type,
            Balance = initialDeposit
        };

        account.TransactionHistory.Add(new Transaction
        {
            TransactionId = Guid.NewGuid().ToString(),
            TransactionDate = DateTime.Now,
            Type = "Deposit",
            Amount = initialDeposit,
            Description = "Initial Deposit"
        });

        _accounts.Add(account);
    }

    // Deposit
    public bool Deposit(string accountNumber, double amount)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null || amount <= 0)
            return false;

        account.Balance += amount;
        account.TransactionHistory.Add(new Transaction
        {
            TransactionId = Guid.NewGuid().ToString(),
            TransactionDate = DateTime.Now,
            Type = "Deposit",
            Amount = amount,
            Description = "Cash Deposit"
        });

        return true;
    }

    // Withdraw
    public bool Withdraw(string accountNumber, double amount)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null || amount <= 0 || amount > account.Balance)
            return false;

        account.Balance -= amount;
        account.TransactionHistory.Add(new Transaction
        {
            TransactionId = Guid.NewGuid().ToString(),
            TransactionDate = DateTime.Now,
            Type = "Withdrawal",
            Amount = amount,
            Description = "Cash Withdrawal"
        });

        return true;
    }

    // Group Accounts by Type
    public Dictionary<string, List<Account>> GroupAccountsByType()
    {
        return _accounts
            .GroupBy(a => a.AccountType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Account Statement
    public List<Transaction> GetAccountStatement(string accountNumber,
                                                 DateTime from, DateTime to)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null)
            return new List<Transaction>();

        return account.TransactionHistory
            .Where(t => t.TransactionDate >= from && t.TransactionDate <= to)
            .ToList();
    }

    // Helpers for menu
    public List<Account> GetAllAccounts() => _accounts;
}
