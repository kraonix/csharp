using System;

class LoginAttemptsExceededException : Exception
{
    public LoginAttemptsExceededException(string message) : base(message) { }
}

class LoginSystem
{
    static void Main()
    {
        int attempts = 0;
        string correctPassword = "admin123";

        try
        {
            while (true)
            {
                Console.Write("Enter password: ");
                string input = Console.ReadLine();

                if (input == correctPassword)
                {
                    Console.WriteLine("Login successful!");
                    break;
                }
                else
                {
                    attempts++;
                    Console.WriteLine($"Wrong password! {3 - attempts} attempts Remaining!");

                    if (attempts >= 3)
                    {
                        throw new LoginAttemptsExceededException("Too many failed login attempts. Access blocked.");
                    }
                }
            }
        }
        catch (LoginAttemptsExceededException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("System shutting down.");
        }
    }
}
