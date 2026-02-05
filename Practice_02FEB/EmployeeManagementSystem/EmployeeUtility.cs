namespace EMS
{
    public class EmployeeUtility
    {
        //Collection of Employee Class
        private List<Employee> employees = new List<Employee>();
        
        private int idCounter = 1;

        // In class HRManager:
        // Auto-generate EmployeeId (E001, E002...)
        public void AddEmployee(string name, string dept, double salary)
        {
            Employee emp = new Employee()
            {
                EmployeeID = idCounter++,
                Name = name,
                Department = dept,
                Salary = salary,
                JoiningDate = DateTime.Today
            };

            employees.Add(emp);
        }

        // Groups employees by department
        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            SortedDictionary<string, List<Employee>> result = new SortedDictionary<string, List<Employee>>();

            foreach (var emp in employees)
            {
                if (!result.ContainsKey(emp.Department))
                    result[emp.Department] = new List<Employee>();

                result[emp.Department].Add(emp);
            }

            return result;
        }

        // Returns total salary of a department
        public double CalculateDepartmentSalary(string department)
        {
            double result = 0;
            foreach(var emp in employees)
            {
                if(department == emp.Department)
                {
                    result += emp.Salary;
                }
            }

            return result;
        }

        // Returns employees joined after specific date
        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            var result = employees
           .Where(e => e.JoiningDate > date)
           .ToList(); 

           return result;
        }
    }
}