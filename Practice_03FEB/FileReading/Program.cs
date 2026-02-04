using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        string filePath = "data.txt";

        try
        {
            // 1. Read file content
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("File Content:\n");
                Console.WriteLine(content);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: data.txt file not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: You do not have permission to access this file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("File access attempt logged.");
        }
    }
}
