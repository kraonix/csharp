using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Xml;

public class Student
{
    public int ID;
    public string Name;
    public int Age;
}

public class Board : Student
{
    public string Stream;

    public Board(int id, string name, int age, string stream)
    {
        ID = id;
        Name = name;
        Age = age;
        Stream = stream;
    }
}

public class Graduation : Student
{
    public string CoreSubject;

    public Graduation(int id, String name, int age, string coreSubject)
    {
        ID = id;
        Name = name;
        Age = age;
        CoreSubject = coreSubject;
    }
} 

public class PostGradutaion
{
    public string CoreSubject;

    public Graduation(int id, String name, int age, string coreSubject)
    {
        ID = id;
        Name = name;
        Age = age;
        CoreSubject = coreSubject;
    }
}

public class Program
{
    public static void Main(String[] args)
    {
        Board[] boardStudents =
        {
            new Board(01, "Yash", 17, "Commerce")
        };

        Graduation[] graduation =
        {
            new Graduation(11, "Avni", 20, "CS")
        };

    }   
}