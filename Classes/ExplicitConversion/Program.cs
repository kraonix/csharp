class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

class Man : Person
{
    public string hobby;

    public Man(string name, int age, string hobby) : base(name, age)
    {
        this.hobby = hobby;
    }
}

class Program
{
    public static void Main(String[] args)
    {
        Person p = new Person("Sachin", 22);

        Man man = new Man("Sahil", 19, "Cricket");

        p = man;
        Console.WriteLine($"\n Console: {(Man)p.hobby}");
    }
}