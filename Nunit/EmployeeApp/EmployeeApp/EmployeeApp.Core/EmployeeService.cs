using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Core
{
	
	public class EmployeeService
	{
		private readonly IEmployeeRepository repository; //this interface is acting as a repository background

		public EmployeeService(IEmployeeRepository repository)
		{
			this.repository = repository;
		}

		public int GetEmployeeCount()
		{
			return repository.GetAll().Count;
		}
	}
}