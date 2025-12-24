using CommonLib;

class ScienceLogin : LoginAbs
{
    public override void Login(string username, string password)
    {
        Console.WriteLine("\nScience library login successful.");
        Console.WriteLine("Welcome " + username + " to the Science Library.\n");
    }

    public override void Logout()
    {
        Console.WriteLine("\nScience library logout successful.");
    }
}