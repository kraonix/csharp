using System.Collections.Generic;

namespace EmployeeApp.Core
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
    }
}
