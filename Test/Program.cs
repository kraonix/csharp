
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
        // Calc c = new Calc();
        // string input;
        // bool result;

        // while (true)
        // {
        //     Console.Write("Enter a number ('0' to quit): ");
        //     input = Console.ReadLine();

        //     if (!int.TryParse(input, out int number))
        //     {
        //         Console.WriteLine("Invalid input. Please enter a valid integer.");
        //         continue;
        //     }

        //     if (number == 0)
        //         break;

        //     result = c.IsEven(number);
        //     Console.WriteLine(result ? $"{number} is even." : $"{number} is odd.");
        // }

        Console.Write("Enter a number ('q' to quit): ");
        Calc c = new Calc();
        string? choice = Console.ReadLine();
        int number = 0;
        bool CheckResult = false;


        while (choice != "q"){
            if (int.TryParse(choice, out number)){
                
                CheckResult = c.IsEven(number);
                Console.WriteLine(CheckResult ? $"{number} is even." : $"{number} is odd.");

            }else{
                Console.WriteLine("Invalid input.");
            }

            Console.Write("Enter a number ('q' to quit): ");
            choice = Console.ReadLine();
        }
    }
}    
