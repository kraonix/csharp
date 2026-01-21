class Program
{
    public static int Sum(int[] nums)
    {
        // Function calculating Sum of Posotive Integers
        int total = 0;

        foreach(var v in nums)
        {
            if(v < 0)
            {
                continue;
            }
            else if(v == 0)
            {
                break;
            }
            else
            {
                total += v;
            }
        }

        return total;
    }

    public static void Main(string[] args)
    {
        // Main
        Console.Write("Enter the Length of Array: ");
        int length = int.Parse(Console.ReadLine());

        int[] Nums = new int[length];

        Console.Write("Enter Array Elements : ");
        for(int i = 0; i < length; i++)
        {
            Nums[i] = int.Parse(Console.ReadLine());
        }

        int Result = Sum(Nums);

        Console.WriteLine($"Sum of Positive integers is {Result}");
    }
}