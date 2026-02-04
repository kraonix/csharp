using System;

class FileUpload
{
    static void Main()
    {
        string fileName = "report.exe";
        int fileSize = 8;

        try
        {
            if (!fileName.EndsWith(".pdf"))
                throw new InvalidOperationException("Invalid file type");

            if (fileSize > 5)
                throw new Exception("File size exceeded");

            Console.WriteLine("File uploaded successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
