public class MyData
{
    private string[] values = new string[3];

    //Indexer
    public string this[int index]
    {
        get
        {
            return values[index];
        }
        set
        {
            values[index] = value;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyData obj = new MyData();

        //SET
        obj[0] = "C";
        obj[1] = "C++";
        obj[2] = "C#";

        //GET
        Console.WriteLine($"First Index Value:  {obj[0]}");
        Console.WriteLine($"Second Index Value: {obj[1]}");
        Console.WriteLine($"Third Index Value:  {obj[2]}");
    }
}