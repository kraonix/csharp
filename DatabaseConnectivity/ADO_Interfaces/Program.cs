using Microsoft.Data.SqlClient;
using DotNetEnv;

class Program
{
    static void Main()
    {
        Env.Load();
        string? connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        var services = new EmployeeServices(connection);
        RunMenu(services);
    }

    static void RunMenu(EmployeeServices services)
    {
        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine() ?? "";

            running = ProcessMenuChoice(choice, services);
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n====== EMPLOYEE MENU ======");
        Console.WriteLine("1. Insert Employee");
        Console.WriteLine("2. Update Salary");
        Console.WriteLine("3. Count Employees");
        Console.WriteLine("4. View Employees");
        Console.WriteLine("5. Delete Employee");
        Console.WriteLine("0. Exit");
        Console.Write("Select Option: ");
    }

    static bool ProcessMenuChoice(string choice, EmployeeServices services)
    {
        return choice switch
        {
            "1" => HandleInsert(services),
            "2" => HandleUpdate(services),
            "3" => HandleCount(services),
            "4" => HandleGetAll(services),
            "5" => HandleDelete(services),
            "0" => false,
            _ => DisplayInvalidOption()
        };
    }

    static bool HandleInsert(EmployeeServices services)
    {
        int id = GetIntInput("Enter Id: ");
        string name = GetInput("Enter Name: ");
        decimal salary = GetDecimalInput("Enter Salary: ");
        int dept = GetIntInput("Enter Department: ");
        services.Insert(id, name, salary, dept);
        return true;
    }

    static bool HandleUpdate(EmployeeServices services)
    {
        int id = GetIntInput("Enter EmployeeId: ");
        decimal salary = GetDecimalInput("Enter New Salary: ");
        services.UpdateSalary(id, salary);
        return true;
    }

    static bool HandleCount(EmployeeServices services)
    {
        int total = services.Count();
        Console.WriteLine($"Total Employees: {total}");
        return true;
    }

    static bool HandleGetAll(EmployeeServices services)
    {
        services.GetAll();
        return true;
    }

    static bool HandleDelete(EmployeeServices services)
    {
        int id = GetIntInput("Enter EmployeeId to Delete: ");
        services.Delete(id);
        return true;
    }

    static bool DisplayInvalidOption()
    {
        Console.WriteLine("Invalid Option. Try Again.");
        return true;
    }

    static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    static int GetIntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    static decimal GetDecimalInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out decimal result))
                return result;
            Console.WriteLine("Invalid input. Try again.");
        }
    }
}

class EmployeeServices
{
    private readonly SqlConnection _connection;
    private readonly IInsertEmployee _insertService;
    private readonly IUpdateEmployee _updateService;
    private readonly ICountEmployees _countService;
    private readonly IGetEmployees _getService;
    private readonly IDeleteEmployee _deleteService;

    public EmployeeServices(SqlConnection connection)
    {
        _connection = connection;
        _insertService = new InsertEmployee();
        _updateService = new UpdateEmployee();
        _countService = new CountEmployees();
        _getService = new GetEmployees();
        _deleteService = new DeleteEmployee();
    }

    public void Insert(int id, string name, decimal salary, int dept) =>
        _insertService.Insert(_connection, id, name, salary, dept);

    public void UpdateSalary(int id, decimal salary) =>
        _updateService.UpdateSalary(_connection, id, salary);

    public int Count() =>
        _countService.Count(_connection);

    public void GetAll() =>
        _getService.GetAll(_connection);

    public void Delete(int id) =>
        _deleteService.Delete(_connection, id);
}
