using System.Diagnostics;
using System.Text.Json;

// ================= MODEL =================
public class ProcessInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public long MemoryKB { get; set; }
}

// ================= PROGRAM =================
public class Program
{
    public static void Main(string[] args)
    {
        List<ProcessInfo> processesList = new();

        Process[] processes = Process.GetProcesses();

        foreach (Process p in processes)
        {
                processesList.Add(new ProcessInfo
                {
                    Id = p.Id,
                    Name = p.ProcessName,
                    MemoryKB = p.WorkingSet64 / 1024
                });
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(processesList, options);
        File.WriteAllText("processes.json", json);

        Console.WriteLine("processes.json created successfully");
    }
}
