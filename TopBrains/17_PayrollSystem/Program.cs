using System;

namespace PayrollSystem
{
    // Abstract base class for all employees
    abstract class Employee
    {
        // Abstract method to calculate pay (polymorphism)
        public abstract decimal CalculatePay();
    }

    // Hourly employee class
    class HourlyEmployee : Employee
    {
        decimal rate;
        decimal hours;

        // Constructor
        public HourlyEmployee(decimal rate, decimal hours)
        {
            this.rate = rate;
            this.hours = hours;
        }

        // Override pay calculation
        public override decimal CalculatePay()
        {
            return rate * hours;
        }
    }

    // Salaried employee class
    class SalariedEmployee : Employee
    {
        decimal monthlySalary;

        // Constructor
        public SalariedEmployee(decimal monthlySalary)
        {
            this.monthlySalary = monthlySalary;
        }

        // Override pay calculation
        public override decimal CalculatePay()
        {
            return monthlySalary;
        }
    }

    // Commission employee class
    class CommissionEmployee : Employee
    {
        decimal commission;
        decimal baseSalary;

        // Constructor
        public CommissionEmployee(decimal commission, decimal baseSalary)
        {
            this.commission = commission;
            this.baseSalary = baseSalary;
        }

        // Override pay calculation
        public override decimal CalculatePay()
        {
            return baseSalary + commission;
        }
    }

    public class Program
    {
        // User-defined function to compute total payroll
        static decimal ComputeTotalPayroll(string[] employees)
        {
            decimal totalPay = 0;

            // Check if input array is not null
            if (employees != null)
            {
                // Loop through each employee description
                for (int i = 0; i < employees.Length; i++)
                {
                    // Split input string by space
                    string[] parts = employees[i].Split(' ');

                    Employee emp = null;

                    // Identify employee type based on first character
                    if (parts[0] == "H")
                    {
                        // HourlyEmployee: H rate hours
                        decimal rate = decimal.Parse(parts[1]);
                        decimal hours = decimal.Parse(parts[2]);
                        emp = new HourlyEmployee(rate, hours);
                    }
                    else if (parts[0] == "S")
                    {
                        // SalariedEmployee: S monthlySalary
                        decimal salary = decimal.Parse(parts[1]);
                        emp = new SalariedEmployee(salary);
                    }
                    else if (parts[0] == "C")
                    {
                        // CommissionEmployee: C commission baseSalary
                        decimal commission = decimal.Parse(parts[1]);
                        decimal baseSalary = decimal.Parse(parts[2]);
                        emp = new CommissionEmployee(commission, baseSalary);
                    }

                    // Add calculated pay using polymorphism
                    if (emp != null)
                    {
                        totalPay += emp.CalculatePay();
                    }
                }
            }

            // Round total pay to 2 decimals (AwayFromZero)
            return Math.Round(totalPay, 2, MidpointRounding.AwayFromZero);
        }

        // Main method
        static void Main()
        {
            // Ask user for number of employees
            Console.WriteLine("Enter number of employees");
            int n = int.Parse(Console.ReadLine());

            // Declare input array
            string[] employees = new string[n];

            // Read employee details
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter employee {i + 1} details");
                employees[i] = Console.ReadLine();
            }

            // Compute total payroll
            decimal totalPay = ComputeTotalPayroll(employees);

            // Display result
            Console.WriteLine("Total Payroll: " + totalPay);
        }
    }
}
