using Models;

namespace Data
{
    public static class CustomerData
    {
        private static readonly List<Customer> _customers = new()
        {
            new Customer(1, "Sachin"),
            new Customer(3, "Anushka"),
            new Customer(2, "Sahil")
        };

        public static IReadOnlyList<Customer> Customers => _customers;
        public static void AddCustomer(int id, string name)
        {
            _customers.Add(new Customer(id, name));
        }

        public static Customer? GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public static int GetNextId()
        {
            return _customers.Count == 0 ? 1 : _customers.Max(c => c.Id) + 1;
        }
    }
}
