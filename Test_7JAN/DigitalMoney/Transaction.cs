namespace DigitalMoney
{
    // ===============================
    // ABSTRACT BASE CLASS
    // ===============================
    // Common structure for all transactions
    public abstract class Transaction : IReportable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        protected Transaction(int id, DateTime date, decimal amount, string description)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
        }

        // Each derived class MUST provide its own summary
        public abstract string GetSummary();
    }

    // ===============================
    // EXPENSE TRANSACTION
    // ===============================
    public class ExpenseTransaction : Transaction
    {
        public string Category { get; set; }

        public ExpenseTransaction(int id, DateTime date, decimal amount, string description, string category) : base(id, date, amount, description)
        {
            Category = category;
        }

        public override string GetSummary()
        {
            return $"[EXPENSE] Rs {Amount} | {Category} | {Description} | {Date}";
        }
    }

    // ===============================
    // INCOME TRANSACTION
    // ===============================
    public class IncomeTransaction : Transaction
    {
        public string Source { get; set; }

        public IncomeTransaction(int id, DateTime date, decimal amount, string description, string source) : base(id, date, amount, description)
        {
            Source = source;
        }

        public override string GetSummary()
        {
            return $"[INCOME] Rs {Amount} | Source: {Source} | {Description} | {Date}";
        }
    }
}