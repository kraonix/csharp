public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }

    public Employee(int id, string name, string department)
    {
        Id = id;
        Name = name;
        Department = department;
    }
}