using System;

class Controller
{
    static void Main()
    {
        try
        {
            // Call Service layer
            Service.Process();
        }
        catch (Exception ex)
        {
            // Handle exception at Controller level
            Console.WriteLine("Controller caught error: " + ex.Message);
        }
    }
}

class Service
{
    public static void Process()
    {
        try
        {
            // Call Repository layer
            Repository.GetData();
        }
        catch (Exception ex)
        {
            // Log the error in Service layer
            Console.WriteLine("Service log: " + ex.Message);

            // Rethrow exception to Controller
            throw;
        }
    }
}

class Repository
{
    public static void GetData()
    {
        // Simulate database failure
        throw new Exception("Database connection failed.");
    }
}
