public class User
{
    public string? Name {get; set;}
    public string? Password {get; set;}
    public string? ConfirmationPassword {get; set;}
}

public class PasswordMismatchException : Exception
{
    public PasswordMismatchException (string msg) : base(msg){}
}

public class Program
{
    public static User ValidatePassword(string name, string password, string confirmationPassword)
    {
        User u = new User()
        {
            Name = name,
            Password = password,
            ConfirmationPassword = confirmationPassword
        };

        if (u.Password != u.ConfirmationPassword)
        {
            throw new PasswordMismatchException("Credentials Don't Match");
        }

        return u;
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.Write("Enter Confirmation Password: ");
            string confirmationPassword = Console.ReadLine();

            User u = ValidatePassword(name, password, confirmationPassword);

            Console.WriteLine("Logged In Successfully!");
        }
        catch(PasswordMismatchException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}