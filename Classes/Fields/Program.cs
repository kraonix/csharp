using Example.Fields;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Fields f = new Fields { ID = 1 };

            f.ShowDetails();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
