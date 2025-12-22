using Example.Account;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of SaleAccount and PurchaseAccount
        SaleAccount saleAccount = new SaleAccount
        {
            Account = 9780,
            Name = "Sachin",
            SalesAmount = 150
        };

        PurchaseAccount purchaseAccount = new PurchaseAccount
        {
            Account = 20200,
            Name = "Sahil",
            PurchaseAmount = 800
        };

        // Display account information
        Console.WriteLine("\n" + saleAccount.GetSaleAccountInfo());
        Console.WriteLine(purchaseAccount.GetPurchaseAccountInfo() + "\n");
    }
}