using System;
using System.Linq;
class LamdbaFun
{
    // Main method
    public static void Main()
    {
        int[] arr = new int[10];
        arr[0] = 1;
        arr[1] = 3;
        arr[2] = 5;
        arr[3] = 7;
        arr[4] = 2;
        arr[5] = 9;
        arr[6] = 4;
        arr[7] = 10;
        arr[8] = 6;
        arr[9] = 8;
        var result = arr.Select(x => x > 5);
        Console.WriteLine("Check numbers > 5:");
        foreach (var value in result)
            Console.WriteLine(value);
    }
}
