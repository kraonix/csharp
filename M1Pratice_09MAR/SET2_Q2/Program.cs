using System;
using System.Collections.Generic;

class LibraryManager
{
    public Dictionary<string, List<int>> Manager = new();

    public void addMember(string name)
    {
        if (!Manager.ContainsKey(name))
        {
            Manager[name] = new List<int> { 0, 0, 0 };
        }
    }

    public void imposeFine(string name, int fine)
    {
        if (Manager.ContainsKey(name))
        {
            Manager[name][1] += fine;   // imposed
            Manager[name][2] += fine;   // balance
        }
    }

    public void payFine(string name, int fine)
    {
        if (Manager.ContainsKey(name) && Manager[name][2] >= fine)
        {
            Manager[name][0] += fine;   // paid
            Manager[name][2] -= fine;   // reduce balance
        }
    }

    public string getDetails(string name)
    {
        if (Manager.ContainsKey(name))
        {
            return $"{name} {Manager[name][2]} {Manager[name][1]} {Manager[name][0]}";
        }
        return "Member not found";
    }
}

class Program
{
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        LibraryManager manager = new LibraryManager();

        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            string command = parts[0];

            if (command == "ADD")
            {
                manager.addMember(parts[1]);
            }
            else if (command == "IMPOSE")
            {
                string memberId = parts[1];
                int amount = int.Parse(parts[2]);
                manager.imposeFine(memberId, amount);
            }
            else if (command == "PAY")
            {
                string memberId = parts[1];
                int amount = int.Parse(parts[2]);
                manager.payFine(memberId, amount);
            }
            else if (command == "DETAILS")
            {
                Console.WriteLine(manager.getDetails(parts[1]));
            }
        }
    }
}