using System;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Hello, World!");
//     }
// }



// class Program
// {
//     static void Main()
//     {
//         int number = 17;
//         bool isPrime = true;

//         if (number < 2)
//         {
//             isPrime = false;
//         }
//         else
//         {
//             for (int i = 2; i <= Math.Sqrt(number); i++)
//             {
//                 if (number % i == 0)
//                 {
//                     isPrime = false;
//                     break;
//                 }
//             }
//         }

//         Console.WriteLine(isPrime ? $"{number} is prime" : $"{number} is not prime");
//     }
// }



class Program
{
    static void Main()
    {
        Console.WriteLine("Enter age: ");

        string? input = Console.ReadLine();
        if (int.TryParse(input, out int age))
        {
            bool isAdult = age >= 18;
            Console.WriteLine(isAdult ? "You are an adult." : "You are a minor.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid age.");
        }
    }
}