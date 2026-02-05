using System;

class Program
{
    static void Main()
    {
        BankManager manager = new BankManager();

        // -------- Hardcoded Initial Data --------
        manager.CreateAccount("Amit Sharma", "Savings", 5000);
        manager.CreateAccount("Neha Verma", "Current", 10000);
        manager.CreateAccount("Rahul Mehta", "Fixed", 25000);
        // ---------------------------------------

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nBANK ACCOUNT MANAGEMENT SYSTEM");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Group Accounts by Type");
            Console.WriteLine("5. View Account Statement");
            Console.WriteLine("6. View Account Balances");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Account Holder Name: ");
                    string holder = Console.ReadLine();

                    Console.Write("Account Type (Savings/Current/Fixed): ");
                    string type = Console.ReadLine();

                    Console.Write("Initial Deposit: ");
                    double deposit = double.Parse(Console.ReadLine());

                    manager.CreateAccount(holder, type, deposit);
                    Console.WriteLine("Account created successfully.");
                    break;

                case 2:
                    Console.Write("Account Number: ");
                    string depAcc = Console.ReadLine();

                    Console.Write("Amount: ");
                    double depAmt = double.Parse(Console.ReadLine());

                    Console.WriteLine(manager.Deposit(depAcc, depAmt)
                        ? "Deposit successful."
                        : "Deposit failed.");
                    break;

                case 3:
                    Console.Write("Account Number: ");
                    string withAcc = Console.ReadLine();

                    Console.Write("Amount: ");
                    double withAmt = double.Parse(Console.ReadLine());

                    Console.WriteLine(manager.Withdraw(withAcc, withAmt)
                        ? "Withdrawal successful."
                        : "Withdrawal failed.");
                    break;

                case 4:
                    var grouped = manager.GroupAccountsByType();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nAccount Type: {g.Key}");
                        foreach (var a in g.Value)
                            Console.WriteLine($"{a.AccountNumber} - {a.AccountHolder}");
                    }
                    break;

                case 5:
                    Console.Write("Account Number: ");
                    string stmtAcc = Console.ReadLine();

                    Console.Write("From Date (yyyy-mm-dd): ");
                    DateTime from = DateTime.Parse(Console.ReadLine());

                    Console.Write("To Date (yyyy-mm-dd): ");
                    DateTime to = DateTime.Parse(Console.ReadLine());

                    var statement = manager.GetAccountStatement(stmtAcc, from, to);
                    foreach (var t in statement)
                    {
                        Console.WriteLine(
                            $"{t.TransactionDate} | {t.Type} | {t.Amount} | {t.Description}");
                    }
                    break;

                case 6:
                    foreach (var acc in manager.GetAllAccounts())
                    {
                        Console.WriteLine(
                            $"{acc.AccountNumber} - {acc.AccountHolder} - Balance: {acc.Balance}");
                    }
                    break;

                case 0:
                    exit = true;
                    Console.WriteLine("Exiting application.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
