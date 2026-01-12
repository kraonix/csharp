public class Person
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int Age { get; set; }
}

public class PersonImplementation
{
    public string GetName(IList<Person> person)
    {
        string names = string.Empty;
        foreach(var p in person)
        {
            names += p.Name + " " + p.Address + " ";
        }
        return names;
    }

    public double Average(IList<Person> person)
    {
        double total = 0;
        int count = 0;
        foreach(var p in person)
        {
            total += p.Age;
            count++;
        }

        return total / count;
    }

    public int Max(IList<Person> person)
    {
        return person.Max(p => p.Age);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IList<Person> p = new List<Person>();
        p.Add(new Person {Name = "Aarya", Address = "A2101", Age = 69});
        p.Add(new Person {Name = "Daniel", Address = "A1101", Age = 30});
        p.Add(new Person {Name = "Ira", Address = "H801", Age = 25});
        p.Add(new Person {Name = "Jennifer", Address = "I1704", Age = 33});

        PersonImplementation Person = new PersonImplementation();

        string names = Person.GetName(p);
        double avgAge = Person.Average(p);
        int maxAge = Person.Max(p);

        Console.WriteLine(names);
        Console.WriteLine(avgAge);
        Console.WriteLine(maxAge);

    }
}