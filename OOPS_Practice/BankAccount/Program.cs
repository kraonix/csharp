public class BankAccount{
    protected int Balance;
    private int AccountID;
    public int WithdrawAmount, DepositAmount;

    public BankAccount()
    {
        Balance = 10000;
    }

    public void Withdraw(int WA)
    {
        WithdrawAmount = WA;
        if (WithdrawAmount <= Balance)
        {
            Console.WriteLine($"\n---- Money Successfully Withdrawn ----");
            Balance -= WithdrawAmount;
            Console.WriteLine($"Remaining Balance: {Balance}");
        }
        else
        {
            Console.WriteLine($"\n ---- Insufficient Funds ----");
        }
    }

    public void Deposit(int DA)
    {
        DepositAmount = DA;
        Console.WriteLine($"\n---- Money Successfully Deposited ----");
        Balance += DepositAmount;
        Console.WriteLine($"New Balance: {Balance}");
    }
}

public class Program
{
    public static void Main(string[ ] args)
    {
        BankAccount user = new BankAccount();

        int WA = 1000;
        int DA = 1000;

        user.Withdraw(WA);
        user.Deposit(DA);
    }
}