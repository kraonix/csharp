namespace PayRoll
{
    class HRService
    {
        public static void Notify(Employee emp, PaySlip slip)
        {
            Console.WriteLine(
                $"[HR] Salary processed for {emp.Name} ({slip.EmployeeType})"
            );
        }
    }

    class FinanceService
    {
        public static void Notify(Employee emp, PaySlip slip)
        {
            Console.WriteLine(
                $"[Finance] Net Salary {slip.NetSalary} credited for EmpId {emp.Id} \n"
            );
        }
    }
}