public class Employee
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Email {get; set;}
    public int Salary {get; set;}
    int DefaultSalary = 30000;
    public Employee(int id, string name, string email, int salary)
    {
        Id = id;
        Name = name;
        EmailValid(email);
        if(salary <= 0)
        {
            Salary = DefaultSalary;
        }
        else
        {
            Salary = salary;
        }
    }

    public void EmailValid(string email)
    {
        if (!email.Contains("@"))
        {
            Email = email + "@company.com";
        }
        else
        {
            Email = email;
        }
    }
}

public class Program
{
    private static List<Employee> employees = new();
    public static void Main(string[] args)
    {
        employees.Add(new Employee(1, "Sachin", "sachin", 20000));
        employees.Add(new Employee(2, "Anuska", "anuska@gmail.com", 0));
        employees.Add(new Employee(3, "Devi", "Devi@ok.com", 50000));

        foreach(var emp in employees)
        {
            Console.WriteLine("Name:" + emp.Name);
            Console.WriteLine("Email:" + emp.Email);
            Console.WriteLine("Salary:" + emp.Salary + "\n");
        }
    }
}

