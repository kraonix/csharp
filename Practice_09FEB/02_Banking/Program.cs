public class BankAccount
{
    private double _balance = 0;

    public void Deposit(double Amount)
    {
        if (Amount > 0)
        {
            _balance += Amount;
            Console.WriteLine($"Money Deposited Successfully\nNew Balance: {_balance}");
        }
        else
        {
            Console.WriteLine($"Deposit Amount should be Greater than 0!\nCurrent Balance: {_balance}");            
        }
    }

    public void Withdraw(double Amount)
    {
        if(Amount > 0 && Amount <= _balance)
        {
            _balance -= Amount;
            Console.WriteLine($"Money Withdrawn Successfully\nNew Balance: {_balance}");
        }
        else
        {
            Console.WriteLine($"Withdraw Amount should be Greater than 0 and Less than Current Balance!\nCurrent Balance: {_balance}"); 
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BankAccount account = new();
        account.Deposit(5000);
        account.Withdraw(1500);
        account.Deposit(500);
        account.Withdraw(100);
        account.Withdraw(1100);
    }
}