using System;
using System.IO;

string filePath = Path.Combine(@"C:\Users\SACHIN\Desktop\.NET\FileHandling\WriteUsingStreamWriter", "biglog.txt");

using (var writer = new StreamWriter(filePath, append: true))
{
    writer.WriteLine("Line 1");
    writer.WriteLine("Line 2");
}

Console.WriteLine("StreamWriter done.");