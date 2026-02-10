using System;
using System.Linq;
using System.Reflection;

public interface IPlugin
{
    string Key { get; }          // e.g. "excel", "pdf"
    void Execute();
}

public class PdfPlugin : IPlugin
{
    public string Key => "pdf";
    public void Execute() => Console.WriteLine("Exporting as PDF...");
}

public class ExcelPlugin : IPlugin
{
    public string Key => "excel";
    public void Execute() => Console.WriteLine("Exporting as Excel...");
}

public static class PluginRunner
{
    public static void Run(string key)
    {
        var asm = Assembly.GetExecutingAssembly();

        var pluginType = asm.GetTypes()
            .Where(t => typeof(IPlugin).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .Select(t => (IPlugin)Activator.CreateInstance(t)!)
            .FirstOrDefault(p => p.Key.Equals(key, StringComparison.OrdinalIgnoreCase));

        if (pluginType == null)
        {
            Console.WriteLine("Plugin not found: " + key);
            return;
        }

        pluginType.Execute();
    }
}

class Program
{
    static void Main()
    {
        PluginRunner.Run("excel");
        PluginRunner.Run("pdf");
        PluginRunner.Run("image");
    }
}