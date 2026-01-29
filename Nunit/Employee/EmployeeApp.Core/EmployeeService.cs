namespace EmployeeApp.Core
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public int GetEmployeeCount()
        {
            return _repository.GetAll().Count;
        }
    }
}
