using System;

class Program
{
    // User-defined function to compute average of non-null values
    static double? ComputeAverage(double?[] values)
    {
        double sum = 0;          // To store sum of non-null values
        long count = 0;          // To count non-null values

        // Check if array is not null
        if (values != null)
        {
            // Loop through each element of the array
            for (int i = 0; i < values.Length; i++)
            {
                // Process only non-null values
                if (values[i].HasValue)
                {
                    sum += values[i].Value; // Add value to sum
                    count++;                // Increment count
                }
            }
        }

        // If no non-null values exist, return null
        if (count == 0)
            return null;

        // Calculate average and round to 2 decimals (AwayFromZero)
        return Math.Round(sum / count, 2, MidpointRounding.AwayFromZero);
    }

    // User-defined Main method
    static void Main()
    {
        // User-defined nullable double array
        double?[] values = new double?[] { 1.234, null, 2.345, 3.456, null };

        // Call user-defined function
        double? result = ComputeAverage(values);

        // Display result
        if (result.HasValue)
            Console.WriteLine("Average: " + result.Value);
        else
            Console.WriteLine("Average: null");
    }
}
