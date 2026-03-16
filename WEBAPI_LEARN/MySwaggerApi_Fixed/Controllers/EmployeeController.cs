using Microsoft.AspNetCore.Mvc;

namespace MySwaggerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>
        {
            new Employee(1, "Sachin", "IT"),
            new Employee(2, "Anushka", "HR"),
            new Employee(3, "Devi", "Finance")
        };

        // GET all employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(Employees);
        }

        // ADD employee
        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            return Ok(new { Message = "Employee added successfully", Employees });
        }

        // UPDATE employee
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound("Employee not found");

            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;

            return Ok(new
            {
                Message = "Employee updated successfully",
                Employees
            });
        }

        // DELETE employee
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound("Employee not found");

            Employees.Remove(employee);

            return Ok(new
            {
                Message = "Employee deleted successfully",
                Employees
            });
        }
    }
}