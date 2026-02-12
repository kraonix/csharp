using System;
using System.IO;

string filePath = Path.Combine(@"C:\Users\SACHIN\Desktop\.NET\FileHandling\AppendTextFile", "notes.txt");
File.AppendAllText(filePath, $"Log at {DateTime.Now:HH:mm:ss}\n");

Console.WriteLine("Appended successfully.");