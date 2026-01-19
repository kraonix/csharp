class Employee
{
    public int? ID { get; set; }
    public string? Name { get; set; }
}

class Program
{
    public static List<Employee> employees = new List<Employee>();

    public static void Main(string[] args)
    {
        employees.Add(new Employee { ID = 1, Name = "Sachin" });

        Console.Write("Enter Employee ID to search: ");
        int id = int.Parse(Console.ReadLine()!);

        var filteredEmployee = employees.FirstOrDefault(e => e.ID == id);

        if (filteredEmployee == null)
        {
            Console.WriteLine("Employee not found.");
        }
        else
        {
            Console.WriteLine("Employee Found:");
            Console.WriteLine($"ID: {filteredEmployee.ID}, Name: {filteredEmployee.Name}");
        }
    }
}
