/// <summary>
/// Interface to be implemented in Program Class
/// </summary>
public interface SimpleInterface
{
    public void DisplayMessage(string message);
}

class Program : SimpleInterface // Implementing Interface
{
    public static void Main(string[] args)
    {
        Program p = new Program();
        p.DisplayMessage("Hello World");
    }

    public void DisplayMessage(string message) // Implementing Interface Method in Program Class
    {
        Console.Write("\nEnter a Message: ");
        message = Console.ReadLine();
        Console.WriteLine($"Your message: {message}\n");
    }
}