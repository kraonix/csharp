// using System;
// using LogicalPrograms;
// namespace LogicalPrograms
// {
//     class Program
// {
//    public  static void Main()
//     {
//         // Palindrome check
//         Console.Write("Enter a word or sentence: ");
//         string? input = Console.ReadLine();
//         // Using the extension method from Palindrome class
//         bool result = input.IsPalindrome();
//         if (result)
//             Console.WriteLine("It is a Palindrome.");
//         else
//             Console.WriteLine("It is NOT a Palindrome.");
//     }
// }
// }

//=======================================================
// using System;
// using System.Text.RegularExpressions;

// class Program
// {
//     static void Main()
//     {
//         string username = "gopi_123";
//         string pattern = @"^[A-Za-z0-9_]{3,12}$";

//         bool ok = Regex.IsMatch(username, pattern);
//         Console.WriteLine(ok ? "Valid" : "Invalid");
//     }
// }
//================================================================================

// using System;
// using System.Text.RegularExpressions;
// class Program
// {
//     static void Main()
//     {
//         string input = " Error:TIMEOUT while calling API";
//         string pattern = @"timeout";

//         var rx = new Regex(
//             pattern,
//             RegexOptions.IgnoreCase,
//             TimeSpan.FromMilliseconds(0.5) // match timeout
//         );

//         Console.WriteLine(rx.IsMatch(input) ? "Found" : "Not Found");
//     }
// }

//==================================================================
// using System;
// class Program
// {
//     public static void Main()
//     {
//         var list=new List<byte[]>();
        
//         for(int i = 0; i < 200000; i++)
//         {
//             list.Add(new byte[1024]);
//         }
//         Console.WriteLine("Allocate");
//         Console.WriteLine("Total memory: "+GC.GetTotalMemory(forceFullCollection: false));
//     }
// }

//====================================================================================
// using System;
// class Program
// {
//     public static void Main()
//     {
//         var list=new List<double[]>();
        
//         for(int i = 0; i < 20000; i++)
//         {
//             list.Add(new double[1024]);
//         }
//         Console.WriteLine("Allocate");
//         Console.WriteLine("Total memory: "+GC.GetTotalMemory(forceFullCollection: false));
//     }
// }
//======================================================================================================================
// using System;
// class Program
// {
//     public static void Main()
//     {
//         string name="Anuska Palit";
//         int a=1;
//         int b=2;
//         double d=50.2;
//         int c=a+b;
//         int[] arr=new int[100];
//         Console.WriteLine("Allocate");
//         Console.WriteLine("Total memory: "+GC.GetTotalMemory(forceFullCollection: false));
//     }
// }
//==========================================================================================================
// using System;
// using ExtentionMethodDemo;

// class Program
// {
//     public static void Main()
//     {
//         BigMan obj = new BigMan();

//         obj.Names.Add("Anuska");
//         obj.Names.Add("Rahul");
//         obj.Names.Add("Sneha");

//         Console.WriteLine("Before Dispose:");
//         foreach (var name in obj.Names)
//             Console.WriteLine(name);

//         obj.Dispose();

//         Console.WriteLine("\nAfter Dispose:");

//         if (obj.Names == null)
//             Console.WriteLine("Names collection released successfully.");
//         else
//             Console.WriteLine("Still allocated.");
//     }
// }

//=========================================================================================================
class Program
{
    static void Main()
    {
        MyCollection c = new MyCollection();

        c.Add("Anuska");
        c.Add("Rahul");
        c.Add("Sneha");

        Console.WriteLine(c.Contains("Rahul"));
        Console.WriteLine(c.Count);

        c.Clear();

        Console.WriteLine(c.Count);
    }
}
//======================================================================================================================

