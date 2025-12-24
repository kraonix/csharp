using MathsLib;
using ScienceLib;

class CalculatorMain
{
    /// <summary>
    /// Main entry point for the Calculator application.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("\nCalculator Application Started.");

        Console.WriteLine("\nChoose the library to use:");
        Console.WriteLine("1. Maths Library");
        Console.WriteLine("2. Science Library");
        Console.Write("Enter your choice (1 or 2): ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            ///<summary>
            /// Maths library operations
            ///</summary>
            /// <remarks>
            /// This section handles user login, performs basic algebraic operations,
            /// and logs the user out.
            /// </remarks>
            MathsLogin mathsLogin = new MathsLogin(); // Create MathsLogin instance

            Console.Write("Enter username: ");
            string user = Console.ReadLine();

            Console.Write("Enter password: ");
            string pass = Console.ReadLine();

            mathsLogin.Login(user, pass); // User login

            Algebra algebra = new Algebra();
            Console.WriteLine("Choose an operation:");
            Console.WriteLine(" 1. Add\n 2. Subtract\n 3. Multiply\n 4. Divide");

            Console.Write("Enter your choice (1-4): "); // Get operation choice
            string operation = Console.ReadLine();

            Console.Write("Enter first number: "); // Get first number
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: "); // Get second number
            int num2 = int.Parse(Console.ReadLine());

            switch (operation) // Perform selected operation
            {
                case "1":
                    Console.WriteLine($"Result: {algebra.Add(num1, num2)}");
                    break;
                case "2":
                    Console.WriteLine($"Result: {algebra.Subtract(num1, num2)}");
                    break;
                case "3":
                    Console.WriteLine($"Result: {algebra.Multiply(num1, num2)}");
                    break;
                case "4":
                    try
                    {
                        Console.WriteLine($"Result: {algebra.Divide(num1, num2)}");
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation choice.");
                    break;
            }

            mathsLogin.Logout();
        }
        else if (choice == "2")
        {
            ScienceLogin scienceLogin = new ScienceLogin();

            Console.Write("Enter username: ");
            string user = Console.ReadLine();

            Console.Write("Enter password: ");
            string pass = Console.ReadLine();

            scienceLogin.Login(user, pass);

            Console.WriteLine(" Choose a science operation:");
            Console.WriteLine(" 1. Lift Calculation\n 2. Drag Calculation");
            Console.Write("Enter your choice (1-2): ");
            string operation = Console.ReadLine();


            // Get parameters for calculations
            Console.Write("Enter velocity (m/s): ");
            double velocity = double.Parse(Console.ReadLine());
            Console.Write("Enter area (m^2): ");
            double area = double.Parse(Console.ReadLine());
            const double airDensity = 1.225;                // kg/m^3
            const double liftCoefficient = 1.2;             // Example coefficient

            switch (operation) // Perform selected operation
            {
                case "1":
                    double lift = 0.5 * airDensity * velocity * velocity * area * liftCoefficient;
                    Console.WriteLine($"Calculated Lift: {lift} N");
                    break;
                case "2":
                    const double dragCoefficient = 0.47; // Example coefficient for a sphere
                    double drag = 0.5 * airDensity * velocity * velocity * area * dragCoefficient;
                    Console.WriteLine($"\nCalculated Drag: {drag} N");
                    break;
                default:
                    Console.WriteLine("Invalid operation choice.");
                    break;
            }

            scienceLogin.Logout();
        }
        else
        {
            Console.WriteLine("Invalid choice. Exiting application.");
        }
    }
}