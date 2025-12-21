using System.Runtime.CompilerServices;

class Employee
{
    public int Id;
    public string Name;

    // Constructor
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class Competition
{
    public int CompID;
    public string Title;


    // Constructor
    public Competition(int compID, string title)
    {
        CompID = compID;
        Title = title;
    }
}

class CompetitionResult
{
    public Employee Employee;
    public Competition Competition;
    public int Score;
    public int Rank;

    // Constructor
    public CompetitionResult(Employee employee, Competition competition, int score)
    {
        Employee = employee;
        Competition = competition;
        Score = score;
    }
}

class Program
{
    public static void Main(String[] args)
    {

        Employee[] employees = {
            new Employee(0, "Sachin"),
            new Employee(1, "Sahil"),
            new Employee(2, "Arzoo"),
            new Employee(3, "Raj"),
            new Employee(4, "Shubham")
        };

        Competition[] competitions = {
            new Competition(0, "Coding"),
            new Competition(1, "Design"),
            new Competition(2, "Testing")
        };

        CompetitionResult[] results = {
            new CompetitionResult(employees[0], competitions[0], 85),
            new CompetitionResult(employees[1], competitions[0], 89),
            new CompetitionResult(employees[2], competitions[0], 78),
            new CompetitionResult(employees[3], competitions[0], 81),
            new CompetitionResult(employees[4], competitions[0], 84),
            new CompetitionResult(employees[0], competitions[1], 80),
            new CompetitionResult(employees[1], competitions[1], 85),
            new CompetitionResult(employees[2], competitions[1], 82),
            new CompetitionResult(employees[3], competitions[1], 81),
            new CompetitionResult(employees[4], competitions[1], 90),
            new CompetitionResult(employees[0], competitions[2], 75),
            new CompetitionResult(employees[1], competitions[2], 80),
            new CompetitionResult(employees[2], competitions[2], 70),
            new CompetitionResult(employees[3], competitions[2], 78),
            new CompetitionResult(employees[4], competitions[2], 86)
        };

        int WinnerScore = 85;

        Console.WriteLine();
        Console.WriteLine("Employee Competition Results:");
        foreach (var result in results)
        {   
            if (result.Score > WinnerScore){
                Console.WriteLine($"Employee: {result.Employee.Name}\nCompetition: {result.Competition.Title}\nScore: {result.Score}");
                Console.WriteLine();
            }
        }

    }
}