namespace DigitalMoney
{
    // ===============================
    // GENERIC LEDGER CLASS
    // ===============================
    // T must be a Transaction
    public class Ledger<T> where T : Transaction
    {
        // Internal storage (in-memory only)
        private List<T> entries = new List<T>();

        // Add a transaction entry
        public void AddEntry(T entry)
        {
            entries.Add(entry);
        }

        // Get all transactions for a specific date
        public List<T> GetTransactionByDate(DateTime date)
        {
            return entries
                .Where(e => e.Date.Date == date.Date)
                .ToList();
        }

        // Expose all entries (read-only)
        public List<T> GetAllEntries()
        {
            return new List<T>(entries);
        }
    }
}