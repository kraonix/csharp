class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the size");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the elements");
        List<int> input = [];
        for (int i = 0; i < size; i++)
        {
            input.Add(int.Parse(Console.ReadLine()));
        }
        HashSet<int> output = [..input];
        Console.WriteLine(string.Join(" , ", output));
    }
}
