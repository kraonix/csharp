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



// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Enter age: ");

//         string? input = Console.ReadLine();
//         if (int.TryParse(input, out int age))
//         {
//             bool isAdult = age >= 18;
//             Console.WriteLine(isAdult ? "You are an adult." : "You are a minor.");
//         }
//         else
//         {
//             Console.WriteLine("Invalid input. Please enter a valid age.");
//         }
//     }
// }



// class Program
// {
//     static void Main()
//     {
//         const double CmPerFoot = 30.48;

//         Console.Write("Enter feet: ");
//         string? input = Console.ReadLine();

//         if (!double.TryParse(input, out double feet))
//         {
//             Console.WriteLine("Invalid input. Please enter a number.");
//             return;
//         }

//         if (feet < 0)
//         {
//             Console.WriteLine("Feet cannot be negative.");
//             return;
//         }

//         double cm = feet * CmPerFoot;
//         Console.WriteLine($"{feet} feet = {cm:F2} cm");
//     }
// }



class Program
{
    /// <summary>
    /// Checks if a number is even.
    /// </summary>
    public class Calc()
    {
        public bool IsEven(int number)
        {
            // Return true if number is even, false otherwise
            return number % 2 == 0;
        }
    }

    // Main method
    public static void Main()
    {
        // Create an instance of calc and test isEven method
        Calc c = new Calc();

        while (true)
        {
            Console.Write("Enter a number ('0' to quit): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }

            if (number == 0)
                break;

            bool result = c.IsEven(number);
            Console.WriteLine(result ? $"{number} is even." : $"{number} is odd.");
        }
    }
}
