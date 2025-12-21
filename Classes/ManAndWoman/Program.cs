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

    public Person()
    {
        ID = 0;
        Name = string.Empty;
        Age = 0;
    }
    public Person(int id, string name, int age)
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
        Program p = new Program();

        Person person = new Person();

        Man man = new Man(2, "Sahil", 19, "Cricket");
        Woman woman = new Woman(3, "Avni", 20, "School");

        Console.WriteLine();
        Console.WriteLine(p.PersonDetails(man));
        Console.WriteLine(p.PersonDetails(woman));
    }

    public string PersonDetails(Person person)
    {
        if(person is Man)
        {
            Man man = (Man) person;
            return $"Name : {person.Name} \nAge : {person.Age} \nPlaying : {man.Playing} \n";

        }else if(person is Woman)
        {
            Woman woman = (Woman) person;
            return $"Name : {person.Name} \nAge : {person.Age} \nManaging: {woman.Managing} \n";

        }else{
            return $"Name : {person.Name} \nAge : {person.Age}\n";
        }
    }
}