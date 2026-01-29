using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Core
{

	public interface IEmployeeRepository
	{
		List<Employee> GetAll();
	}

}
