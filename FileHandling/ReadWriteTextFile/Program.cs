using System;
using System.IO;

string filePath = Path.Combine(@"C:\Users\SACHIN\Desktop\.NET\FileHandling\ReadWriteTextFile", "notes.txt");
File.WriteAllText(filePath, "Hello!\nThis is written by C#.\n");

Console.WriteLine("Written successfully.");
Console.Write(filePath);