using CommonLib;

class MathsLogin : LoginAbs
{
    public override void Login(string username, string password)
    {
        Console.WriteLine("\nMaths library login successful.");
        Console.WriteLine("Welcome " + username + " to the Maths Library.\n");
    }

    public override void Logout()
    {
        Console.WriteLine("\nMaths library logout successful.");
    }
}