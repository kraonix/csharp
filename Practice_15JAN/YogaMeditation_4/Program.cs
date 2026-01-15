using System;
using System.Collections;

public class MeditationCenter
{
    public int? MemberID { get; set; }
    public int? Age { get; set; }
    public double? Weight { get; set; }   // kg
    public double? Height { get; set; }   // meters
    public string? Goal { get; set; }
    public double? BMI { get; private set; }

    public void CalculateBMI()
    {
        if (Weight.HasValue && Height.HasValue && Height != 0)
        {
            BMI = Weight / (Height * Height);
        }
    }
}

public class Program
{
    public static ArrayList memberList = new ArrayList();

    public static void AddYogaMember(int id, int age, double weight, double height, string goal)
    {
        MeditationCenter m = new MeditationCenter
        {
            MemberID = id,
            Age = age,
            Weight = weight,
            Height = height,
            Goal = goal
        };

        m.CalculateBMI();
        memberList.Add(m);
    }

    public static double calculateBMI(int memberId)
    {
        foreach (MeditationCenter m in memberList)
        {
            if (m.MemberID == memberId)
            {
                return m.BMI ?? 0;
            }
        }
        return -1; // member not found
    }

    public static int CalculateFee(int memberID)
    {
        foreach (MeditationCenter m in memberList)
        {
            if (m.MemberID == memberID)
            {
                // Goal-based fee
                if (m.Goal != null && m.Goal.ToLower() == "weight gain")
                {
                    return 2500;
                }

                // BMI-based fee
                double bmi = m.BMI ?? 0;

                if (bmi >= 25 && bmi < 30)
                    return 2000;
                else if (bmi >= 30 && bmi < 35)
                    return 2500;
                else if (bmi >= 35)
                    return 3000;
                else
                    return 1500; // normal BMI
            }
        }

        return -1; // member not found
    }


    public static void Main()
    {
        Console.WriteLine("Enter Number of Members:");
        int total = int.Parse(Console.ReadLine());

        for (int i = 0; i < total; i++)
        {
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Weight (kg): ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Enter Height (meters): ");
            double height = double.Parse(Console.ReadLine());

            Console.Write("Your Goal: ");
            string goal = Console.ReadLine();

            AddYogaMember(i + 1, age, weight, height, goal);
            Console.WriteLine();
        }

        Console.Write("Enter Member ID to view BMI: ");
        int id = int.Parse(Console.ReadLine());

        double bmi = calculateBMI(id);
        if (bmi == -1)
            Console.WriteLine("Member not found");
        else
            Console.WriteLine($"BMI of Member {id} is {bmi:F2}");

        Console.Write($"\nCalculated Fees for you : {CalculateFee(id)}");
    }
}
