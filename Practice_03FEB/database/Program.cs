using System;

class DatabaseConnection
{
    static void Main()
    {
        bool isConnected = false;

        try
        {
            isConnected = true;
            Console.WriteLine("Connection opened");
            throw new Exception("Operation failed");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (isConnected)
                Console.WriteLine("Connection closed");
        }
    }
}
