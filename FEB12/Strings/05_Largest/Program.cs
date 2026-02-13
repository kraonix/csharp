class Program
{
    static int Largest(int[] arr)
    {
        int max = arr[0];
        foreach (var i in arr)
        {
            if (i > max)
            {
                max = i;
            }
        }
        return max;
    }

    static void Main()
    {
        Console.WriteLine("Enter size");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter elements");
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine($"The maximum: {Largest(arr)}");
    }
}
