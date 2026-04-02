using System.Collections.Generic;

public class PlayListManager
{
    private LinkedList<string> playlist = new LinkedList<string>();

    public void ADD(string song)
    {
        var node = playlist.Find(song);

        if (node == null)
        {
            playlist.AddLast(song);
        }

    }

    public void REMOVE(string song)
    {
        var node = playlist.Find(song);

        if (node == null)
        {
            playlist.Remove(song);
        }
    }

    public void TOP(string song)
    {
            playlist.Remove(song);
            playlist.AddFirst(song);
    }

    public void PRINT()
    {
        foreach (var song in playlist)
        {
            Console.Write(song + " ");
        }
    }
}

public class Set3_02
{
    static PlayListManager manager = new PlayListManager();
    public static void Resolver(string input)
    {
        List<string> commands = input.Split(' ').ToList();
        if (commands[0] == "ADD")
        {
            manager.ADD(commands[1]);
        }
        else if (commands[0] == "REMOVE")
        {
            manager.REMOVE(commands[1]);
        }
        else if (commands[0] == "TOP")
        {
            manager.TOP(commands[1]);
        }
        else if (commands[0] == "PRINT")
        {
            manager.PRINT();
        }

    }
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string input = "";
        for (int i = 0; i < N; i++)
        {
            input = Console.ReadLine();
            Resolver(input);
        }
    }
}