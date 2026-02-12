using System;
using System.IO;

string baseDir = AppContext.BaseDirectory;
string filePath = Path.Combine(baseDir, "data.txt");

Console.WriteLine(filePath);