using System.Collections.Generic;
public class MemberStats
{
    public string name;
    public List<int> steps;
}
public class Set1_02
{
    public static List<MemberStats> members = new();
    public static void CalculateAverageSteps()
    {

        double result = members.SelectMany(m => m.steps).DefaultIfEmpty(0).Average();
        Console.WriteLine("Overall average weekly steps: " + result);
    }

    public static void RegisterMember()
    {
        string name = Console.ReadLine();
        List<int> steps = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            steps.Add(int.Parse(Console.ReadLine()));
        }

        members.Add(new MemberStats { name = name, steps = steps });
    }

    public static void GetHighStepWeeks()
    {
        int threshold = int.Parse(Console.ReadLine());
        Dictionary<string, int> temp = new();

        foreach(MemberStats member in members)
        {
            int count = 0;
            foreach(int step in member.steps)
            {
                if(step >= threshold)
                {
                    count++;
                }
            }
            if(count > 0)
            {
                temp[member.name] = count;
            }
        }


        if (temp.Count == 0)
        {
            Console.WriteLine("No weeks above Threshold Given");
        }

        foreach (var item in temp)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }
    }
    public static void Main()
    {

        bool ok = true;
        while (ok)
        {
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    RegisterMember();
                    Console.WriteLine("Member registered successfully");
                    break;
                case 2:
                    GetHighStepWeeks();
                    break;
                case 3:
                    CalculateAverageSteps();
                    break;
                case 4:
                    Console.WriteLine("Exiting FitPulse — Stay Active!");
                    ok = false;
                    break;
            }
        }
    }
}