class Program
{
    static int Sum(int[] arr)
    {
        int result = 0;
        foreach (var i in arr)
        {
            result += i;
        }
        return result;
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
        Console.WriteLine($"The sum: {Sum(arr)}");
    }
}
