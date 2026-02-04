using System;

class BonusCalculator
{
    static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };
        int bonus = 10000;

        for (int i = 0; i < salaries.Length; i++)
        {
            try
            {
                // 1 & 2. Calculate bonus ratio
                int result = bonus / salaries[i];
                Console.WriteLine($"Employee {i + 1} Bonus Ratio: {result}");
            }
            catch (DivideByZeroException)
            {
                // 3. Handle divide by zero
                Console.WriteLine($"Employee {i + 1}: Salary is zero — bonus cannot be calculated.");
            }
        }

        // 4. Program continues normally
        Console.WriteLine("\nAll employees processed successfully.");
    }
}
