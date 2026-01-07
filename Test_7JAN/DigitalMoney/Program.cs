namespace DigitalMoney
{
    // ===============================
    // PROGRAM
    // ===============================
    class Program
    {
        /// <summary>
        /// Entry point for the Petty Cash Management System that demonstrates ledger operations, transaction tracking, and financial calculations
        /// </summary>
        public static void Main()
        {
            // -------- Income Ledger --------
            Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();

            incomeLedger.AddEntry(new IncomeTransaction(
                id: 1,
                date: DateTime.Now,
                amount: 500,
                description: "Petty cash Addition",
                source: "Main Fund"
            ));

            // -------- Expense Ledger --------
            Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

            expenseLedger.AddEntry(new ExpenseTransaction(
                id: 101,
                date: DateTime.Now,
                amount: 20,
                description: "Office stationery",
                category: "Stationery"
            ));

            expenseLedger.AddEntry(new ExpenseTransaction(
                id: 102,
                date: DateTime.Now,
                amount: 50,
                description: "Snacks",
                category: "Food"
            ));

            // -------- Calculations --------
            // Using Helper Class Functions

            decimal totalIncome = Helper.CalculateTotal(incomeLedger.GetAllEntries());
            decimal totalExpense = Helper.CalculateTotal(expenseLedger.GetAllEntries());
            decimal netBalance = Helper.CalculateNetBalance(incomeLedger.GetAllEntries(), expenseLedger.GetAllEntries());

            // -------- Output --------
            Console.WriteLine("=== PETTY CASH SUMMARY ===\n");

            Console.WriteLine($"Total Income   : Rs {totalIncome}");
            Console.WriteLine($"Total Expense  : Rs {totalExpense}");
            Console.WriteLine($"Net Balance    : Rs {netBalance}\n");

            // -------- Polymorphic Output --------
            Console.WriteLine("=== TRANSACTION DETAILS ===");

            // Combine all transactions from income and expense ledgers for unified display
            List<Transaction> allTransactions = new List<Transaction>();
            allTransactions.AddRange(incomeLedger.GetAllEntries());
            allTransactions.AddRange(expenseLedger.GetAllEntries());

            foreach (Transaction t in allTransactions)
            {
                Console.WriteLine(t.GetSummary());
            }
        }
    }
}