namespace DigitalMoney
{
    // ===============================
    // INTERFACE
    // ===============================
    // Any transaction that can be reported must implement this
    public interface IReportable
    {
        string GetSummary();
    }
}