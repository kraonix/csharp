using System;
using System.IO;

string filePath = Path.Combine(AppContext.BaseDirectory, "notes.txt");
string content = File.ReadAllText(filePath);

Console.WriteLine("File Content:");
Console.WriteLine(content);