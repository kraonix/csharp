public class Student
{
    public int? Roll { get; set; }
    public string? Name { get; set; }
    private string? Address { get; set; }
    private List<string> Books = new List<string>();

    //Indexer
    public string this[int index]
    {
        get
        {
            return Books[index];
        }
        set
        {
            if (index < Books.Count)
            {
                Books[index] = value;
            }
            else
            {
                Books.Add(value);
            }
        }
    }


    //Constructor
    public Student(string address)
    {
        Address = address;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"\n---- Student Details ----");
        Console.WriteLine($"Student Name: {Name}");
        Console.Write($"Books => |");
        foreach (var b in Books)
        {
            Console.Write($" {b} |");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"\n---- Student Portal ----");
        Console.Write($"Enter Roll Number: ");
        int roll = int.Parse(Console.ReadLine());
        Console.Write($"Enter Name: ");
        string name = Console.ReadLine();
        Console.Write($"Enter Address: ");
        string address = Console.ReadLine();

        Student s = new Student(address)
        {
            Roll = roll,
            Name = name
        };

        Console.Write($"\n----- Enter Books ----\n");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Book {i + 1} : ");
            s[i] = Console.ReadLine();
        }

        s.DisplayDetails();
    }
}