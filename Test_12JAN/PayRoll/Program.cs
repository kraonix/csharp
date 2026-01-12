using PayRoll;
/// <summary>
/// Entry point of the PayRoll application that demonstrates the use of multicast delegates
/// and event-driven architecture for payroll processing.
/// This program initializes a list of employees with different contract types (FullTimeEmployee 
/// and ContractEmployee), creates a PayrollProcessor instance, and subscribes multiple services
/// (HRService and FinanceService) to the SalaryProcessed event. The payroll is then processed
/// for all employees, triggering the subscribed event handlers to perform their respective operations.
/// </summary>
class Program
{
    public static void Main(string[] args)
    {
        // Initialize list of employees with different contract types
        List<Employee> employees =
        [
            new FullTimeEmployee(1, "Sachin", 22, "IT", "Delhi", 3, 100000),
            new FullTimeEmployee(2, "Sahil", 19, "IT", "Chandigarh", 1, 60000),
            new FullTimeEmployee(3, "Anuska", 21, "IT", "Banglore", 2, 80000),
            new FullTimeEmployee(4, "Arzoo", 23, "IT", "Trivandrum", 3, 120000),
            new ContractEmployee(5, "Uma", 22, "HR", "Gurgaon", 6, 60000),
            new ContractEmployee(6, "Neeraj", 25, "Sweeper", "Pune", 5, 20000), 
            new ContractEmployee(7, "Raj", 25, "Sweeper", "Ranchi", 2, 15000),
            new ContractEmployee(8, "Ayushi", 25, "HR", "Delhi", 10, 65000)
        ];

        // Create payroll processor instance
        PayrollProcessor processor = new PayrollProcessor();

        // Subscribe multiple services to salary processing events (MULTICAST DELEGATE)
        processor.SalaryProcessed += HRService.Notify;
        processor.SalaryProcessed += FinanceService.Notify;

        Console.WriteLine();

        // Process payroll for all employees
        processor.ProcessPayroll(employees);
    }
}