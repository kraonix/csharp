using System;

public static class BankTransfer
{
    public static void SafeTransfer(Account a, Account b, decimal amount)
    {
        if (a == null || b == null)
            throw new ArgumentException("Account cannot be null.");

        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        if (a == b)
            throw new ArgumentException("Cannot transfer to same account.");

        // Ordered locking by AccountId
        Account firstLock = string.Compare(a.AccountId, b.AccountId) < 0 ? a : b;
        Account secondLock = firstLock == a ? b : a;

        lock (firstLock.LockObj)
        {
            lock (secondLock.LockObj)
            {
                if (a.Balance < amount)
                    throw new InvalidOperationException("Insufficient funds.");

                a.Balance -= amount;
                b.Balance += amount;

                Console.WriteLine($"Transferred {amount} from {a.AccountId} to {b.AccountId}");
            }
        }
    }
}
