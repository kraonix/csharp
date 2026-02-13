class Program
{
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
        
        var output = new Dictionary<int, int>();
        foreach (var num in arr)
        {
            if (output.TryGetValue(num, out int count))
            {
                output[num] = count + 1;
            }
            else
            {
                output[num] = 1;
            }
        }
        
        foreach (var kvp in output)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}