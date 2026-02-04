using System;

class ExceptionRethrow
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Final handler: " + ex.Message);
        }
    }

    static void ProcessData()
    {
        try
        {
            int.Parse("ABC");
        }
        catch (Exception)
        {
            Console.WriteLine("Logged in ProcessData");
            throw;
        }
    }
}
