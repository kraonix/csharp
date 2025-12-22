using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Base class and derived classes to represent different types of accounts
/// </summary>
/// <remarks>
/// This code defines a base class 'Accounts' with common properties and methods,
/// and two derived classes 'SaleAccount' and 'PurchaseAccount' that extend the base class
/// with additional properties and methods specific to sales and purchases respectively.
/// </remarks>
namespace Example.Account
{
    public class Accounts
    {
        // Common properties for all accounts
        public int Account { get; set; }
        public string Name { get; set; }


        // Method to get basic account information
        public string GetAccountInfo()
        {
            return $"Account: {Account}, Name: {Name}";
        }
    }

    public class SaleAccount : Accounts
    {
        public decimal SalesAmount { get; set; }

        public string GetSaleAccountInfo()
        {
            // Build and return sale account information
            string info = string.Empty;
            info += base.GetAccountInfo();
            info += $", Sales Amount: {SalesAmount}";
            return info;
        }
    }

    public class PurchaseAccount : Accounts
    {
        public decimal PurchaseAmount { get; set; }

        public string GetPurchaseAccountInfo()
        {
            // Build and return purchase account information
            string info = string.Empty;
            info += base.GetAccountInfo();
            info += $", Purchase Amount: {PurchaseAmount}";
            return info;
        }
    }
}