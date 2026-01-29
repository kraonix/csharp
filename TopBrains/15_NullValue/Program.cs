class Program
{
    public static double? Mean(double?[] values)
    {
        double? total = 0;
        int? count = 0;

        foreach(var v in values)
        {
            if(v != null)
            {
                total += v;
                count ++;
            }
        }

        double? mean = total/count;
    }
    public static void Main(string[] args)
    {
        Console.Write("Enter the Length of Array: ");
        int Length = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Elements: ");
        double?[] Values = new double?[Length];
        for(int i = 0; i < Length; i++)
        {
            Values[i] = int.Parse(Console.ReadLine());
        }


        double? result = 5l;
    }
}