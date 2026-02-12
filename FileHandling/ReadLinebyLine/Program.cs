using System;
using System.IO;

string filePath = Path.Combine(@"C:\Users\SACHIN\Desktop\.NET\FileHandling\ReadLinebyLine", "biglog.txt");

using (var reader = new StreamReader(filePath))
{
    string? line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}