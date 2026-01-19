class Program
{
    /// <summary>
    /// Finds the largest integer in an array.
    /// </summary>
    public static int LargestInteger(int[] nums)
    {
        // Find the largest integer
        int largest = nums[0];

        // Iterate through the array to find the largest number
        foreach (var num in nums)
        {
            if (num > largest)
                largest = num;
        }
        return largest;
    }

    public static void Main(string[] args)
    {
        // Example usage
        Console.WriteLine("Enter three integers: ");
        int First = int.Parse(Console.ReadLine());
        int Second = int.Parse(Console.ReadLine());
        int Third = int.Parse(Console.ReadLine());

        // Find the largest integer
        int[] numbers = { First, Second, Third };
        int largest = LargestInteger(numbers);

        // Display the result
        Console.WriteLine($"The largest integer is: {largest}");
    }
}