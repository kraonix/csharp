namespace PayRoll
{
    /// <summary>
    /// Represents an employee in the payroll system.
    /// This is an abstract base class that defines common employee properties and behaviors.
    /// </summary>
    /// <remarks>
    /// This class serves as the foundation for different types of employees.
    /// Derived classes must implement the CalculateSalary method to provide their specific salary calculation logic.
    /// </remarks>
    public abstract class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public int BasicPay {get; set;}

        /// <summary>
        /// Initializes a new instance of the Employee class with the specified details.
        /// </summary>
        /// <param name="id">The unique identifier for the employee.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="age">The age of the employee.</param>
        /// <param name="department">The department where the employee works.</param>
        /// <param name="address">The address of the employee.</param>
        protected Employee(int id, string name, int age, string department, string address, int pay)
        {
            Id = id;
            Name = name;
            Age = age;
            Department = department;
            Address = address;
            BasicPay = pay;
        }

        /// <summary>
        /// Calculates the salary for the employee.
        /// </summary>
        /// <returns>The calculated salary amount as a double.</returns>
        /// <remarks>
        /// This method must be implemented by derived classes to provide specific salary calculation logic
        /// based on the employee type and applicable business rules.
        /// </remarks>
        public abstract double CalculateSalary();

    }


    /// <summary>
    /// Represents a full-time employee with experience-based salary calculation.
    /// </summary>
    class FullTimeEmployee(int id, string name, int age, string department, string address, int experience, int pay) : Employee(id, name, age, department, address, pay)
    {
        public int ExperienceYears { get; set; } = experience;
        public override double CalculateSalary()
        {
            double baseSalary = BasicPay;
            return baseSalary + (ExperienceYears * 2000);
        }
    }

    /// <summary>
    /// Represents a contract employee with contract duration-based salary calculation.
    /// </summary>
    class ContractEmployee(int id, string name, int age, string department, string address, int contractMonths, int pay) : Employee(id, name, age, department, address, pay)
    {
        public int ContractMonths { get; set; } = contractMonths;

        /// <summary>
        /// Calculates the salary based on monthly contract rate.
        /// </summary>
        /// <returns>The calculated salary amount.</returns>
        public override double CalculateSalary()
        {
            return BasicPay + (ContractMonths * 250);
        }
    }
}