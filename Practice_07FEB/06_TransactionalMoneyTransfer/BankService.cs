using System;
using System.Collections.Generic;

public class BankService
{
    private readonly Dictionary<string, Account> _accounts = new();
    private readonly List<string> _auditLog = new();

    public BankService()
    {
        // Seed sample accounts
        _accounts["A1"] = new Account { AccountNumber = "A1", Balance = 1000 };
        _accounts["A2"] = new Account { AccountNumber = "A2", Balance = 500 };
    }

    public TransferResult Transfer(string fromAcc, string toAcc, decimal amount)
    {
        // Domain validations
        if (string.IsNullOrWhiteSpace(fromAcc) ||
            string.IsNullOrWhiteSpace(toAcc))
            throw new DomainException("Invalid account number.");

        if (amount <= 0)
            throw new DomainException("Amount must be greater than zero.");

        if (!_accounts.ContainsKey(fromAcc) ||
            !_accounts.ContainsKey(toAcc))
            throw new DomainException("Account not found.");

        if (fromAcc == toAcc)
            throw new DomainException("Cannot transfer to same account.");

        var source = _accounts[fromAcc];
        var target = _accounts[toAcc];

        // Lock both accounts (order by account number to avoid deadlock)
        var firstLock = string.Compare(fromAcc, toAcc) < 0 ? source : target;
        var secondLock = firstLock == source ? target : source;

        lock (firstLock.LockObj)
        {
            lock (secondLock.LockObj)
            {
                try
                {
                    if (source.Balance < amount)
                        throw new DomainException("Insufficient balance.");

                    // Debit
                    source.Balance -= amount;

                    // Simulate possible credit failure
                    if (SimulateRandomFailure())
                        throw new Exception("Credit system failure.");

                    // Credit
                    target.Balance += amount;

                    _auditLog.Add($"SUCCESS: {amount} transferred from {fromAcc} to {toAcc}");

                    return new TransferResult
                    {
                        Success = true,
                        Message = "Transfer successful."
                    };
                }
                catch (Exception ex)
                {
                    // Rollback debit if already deducted
                    if (source.Balance < 0 || source.Balance < amount)
                        source.Balance += amount;

                    _auditLog.Add($"FAILED: {amount} transfer from {fromAcc} to {toAcc} - {ex.Message}");

                    return new TransferResult
                    {
                        Success = false,
                        Message = $"Transfer failed: {ex.Message}"
                    };
                }
            }
        }
    }

    private bool SimulateRandomFailure()
    {
        return new Random().Next(0, 5) == 0; // 20% chance
    }

    public void PrintBalances()
    {
        foreach (var acc in _accounts.Values)
        {
            Console.WriteLine($"{acc.AccountNumber} Balance: {acc.Balance}");
        }
    }

    public void PrintAuditLog()
    {
        Console.WriteLine("\nAudit Log:");
        foreach (var log in _auditLog)
        {
            Console.WriteLine(log);
        }
    }
}
