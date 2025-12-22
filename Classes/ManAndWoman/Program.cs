using System.Data;
using System.Runtime.Intrinsics.X86;

public class Person
{
    /// <summary>
    /// Parent Class
    /// </summary>
    public int ID;
    public string Name;
    public int Age;

    // Constructors
    private Person() // Default Constructor
    {

    }
    public Person(int id, string name, int age) // Parameterized Constructor
    {
        ID = id;
        Name = name;
        Age = age;
    }
}

public class Man : Person
{
    /// <summary>
    /// Child Class of class Person
    /// </summary>
    public String Playing;

    public Man(int id, string name, int age, string playing)
    {
        ID = id;
        Name = name;
        Age = age;
        Playing = playing;
    }
}

public class Woman : Person
{
    /// <summary>
    /// Child Class of class Person
    /// </summary>
    public string Managing;

    public Woman(int id, string name, int age, String managing)
    {
        ID = id;
        Name = name;
        Age = age;
        Managing = managing;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //Main Class
        Program p = new Program(); // Creating object of Main class

        Person person = new Person();

        Man man = new Man(2, "Sahil", 19, "Cricket"); // Creating object of Man
        Woman woman = new Woman(3, "Avni", 20, "School"); // Creating object of Woman

        Console.WriteLine();
        Console.WriteLine(p.PersonDetails(man));
        Console.WriteLine(p.PersonDetails(woman));
    }

    public string PersonDetails(Person person) // Method to display details of Person
    {
        if(person is Man) // Checking the type of object
        {
            Man man = (Man) person;
            return $"Name : {person.Name} \nAge : {person.Age} \nPlaying : {man.Playing} \n";

        }else if(person is Woman) // Checking the type of objects
        {
            Woman woman = (Woman) person;
            return $"Name : {person.Name} \nAge : {person.Age} \nManaging: {woman.Managing} \n";

        }else{
            return $"Name : {person.Name} \nAge : {person.Age}\n";
        }
    }
}