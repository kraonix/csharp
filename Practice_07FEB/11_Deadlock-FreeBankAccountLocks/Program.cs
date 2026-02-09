using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var acc1 = new Account("A1", 1000);
        var acc2 = new Account("A2", 1000);

        var t1 = Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
                BankTransfer.SafeTransfer(acc1, acc2, 5);
        });

        var t2 = Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
                BankTransfer.SafeTransfer(acc2, acc1, 5);
        });

        Task.WaitAll(t1, t2);

        Console.WriteLine($"\nFinal Balances:");
        Console.WriteLine($"{acc1.AccountId}: {acc1.Balance}");
        Console.WriteLine($"{acc2.AccountId}: {acc2.Balance}");
    }
}
