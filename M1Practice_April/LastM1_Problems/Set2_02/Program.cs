using System.Collections.Generic;
using System.Text.RegularExpressions;

public class LibraryManager
{
    public Dictionary<string, List<int>> members = new Dictionary<string, List<int>>();

    public void ADD(string memberID)
    {
        if (!members.ContainsKey(memberID))
        {
            members[memberID] = new List<int> { 0, 0, 0 };
        }
    }

    public void IMPOSE(string memberID, int amount)
    {
        if (members.ContainsKey(memberID))
        {
            members[memberID][1] += amount;
            members[memberID][2] += amount;
        }
    }

    public void PAY(string memberID, int amount)
    {
        if (members.ContainsKey(memberID))
        {
            if(amount > members[memberID][1]) amount = members[memberID][1];
            members[memberID][1] -= amount;
            members[memberID][0] += amount;
        }
    }

    public void DETAILS(string memberID)
    {
        if (members.ContainsKey(memberID))
        {
            Console.WriteLine(memberID + " " + members[memberID][1] + " " + members[memberID][2] + " " + members[memberID][0]);
        }
        else
        {
            Console.WriteLine("Member not Found");
        }
    }
}

public class Set2_02
{
    static LibraryManager manager = new LibraryManager();
    public static void Resolver(string input)
    {
        List<string> temp = input.Split(' ').ToList();
        if (temp[0] == "ADD")
        {
            manager.ADD(temp[1]);
        }
        else if (temp[0] == "IMPOSE")
        {
            manager.IMPOSE(temp[1], int.Parse(temp[2]));
        }
        else if (temp[0] == "PAY")
        {
            manager.PAY(temp[1], int.Parse(temp[2]));
        }
        else if (temp[0] == "DETAILS")
        {
            manager.DETAILS(temp[1]);
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