namespace Example.Employee
{
    public class Employee
    {
        /// <summary>
        /// The unique identifier for the employee.
        /// </summary>
        private int employeeId;
        private string employeeName;
        private int rank;

        public string ErrorMessage;

        public int EmployeeId
        {
            /// <summary>
            /// Gets the employee identifier.
            /// </summary>
            /// <returns>The unique identifier of the employee.</returns>
            get { return employeeId; }

            set // Sets the employee id. 
            {
                 if(value <= 0)
                 {
                    ErrorMessage += $"Employee ID must be positive.              ({DateTime.Now})\n";
                    throw new ArgumentException("Employee ID must be positive.");
                 }else
                 {
                     employeeId = value;
                 }
            }
        }
        public string EmployeeName
        {
            get { return employeeName; }

            set // Sets the employee name.
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    ErrorMessage += $"Employee Name cannot be empty.              ({DateTime.Now})\n";
                    throw new ArgumentException("Employee Name cannot be empty.");
                }else
                {
                    employeeName = value;
                }
            }
        }

        public int Rank
        {
            get { return rank; }

            set  // Sets the employee rank.
            {
                if(value < 1 || value > 10)
                {
                    ErrorMessage += $"Rank must be between 1 and 10.              ({DateTime.Now})\n";
                    throw new ArgumentException("Rank must be between 1 and 10.");
                }else
                {
                    rank = value;
                }
            }
        }

        public void DisplayInfo()
        {
            /// <summary>
            /// Displays the employee information.
            /// </summary>
            Console.WriteLine("\nEmployee Information:");
            Console.WriteLine($"Employee ID: {employeeId}");
            Console.WriteLine($"Employee Name: {employeeName}");
            Console.WriteLine($"Employee Rank: {rank}\n");
        }

        public void GetErrorMessage()
        {
            Console.WriteLine("\n" + ErrorMessage);
        }
    }
}