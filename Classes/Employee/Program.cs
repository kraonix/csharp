using Example.Employee;

class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        /// <summary>
        /// Creates an instance of Employee, sets properties, and displays information.
        /// </summary>
        try
        {
            Employee emp = new Employee(); // Create an Employee object

            // Setting properties using public accessors
            emp.EmployeeId = 1;
            emp.EmployeeName = "Sachin";
            emp.Rank = 2;

            emp.DisplayInfo();
            
            emp.GetErrorMessage();

            //emp.id; // Accessing the employeeId field directly (will cause a compile-time error)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}