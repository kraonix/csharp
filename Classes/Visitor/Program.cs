using Example.ConstructorEX; //Using already created Program

public class Program
{
    /// <summary>
    /// Main Method
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        try
        {
            Program p = new Program();
            //Visitor v = new Visitor();                              //Default Constructor set to Private

            Visitor visit1 = new Visitor(1);                          //Constructor call with 1 parameter
            Visitor visit2 = new Visitor(2, "Sachin");                //Constructor call with 2 parameters
            Visitor visit3 = new Visitor(3, "Sahil", "CS");           //Constructor call with 3 parameters

            //p.Details(visit1);
            //p.Details(visit2);
            //p.Details(visit3);

            p.LogHistory(visit3);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Details(Visitor visitor) //Print Details Method 
    {
        Console.WriteLine();
        Console.WriteLine($"ID: {visitor.ID} \nName: {visitor.Name} \nRequirement: {visitor.Requirement}");
    }

    public void LogHistory(Visitor visitor)
    {
        Console.WriteLine();
        Console.WriteLine(visitor.Logs);
    }
}