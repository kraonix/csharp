class MenuSystem
{
    /// <summary>
    /// Program for a simple menu system.
    /// </summary>
    static void Main()
    {
        int choice;
        do
        {
            // Display menu
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Option 1");
            Console.WriteLine("2. Option 2");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            
            // Read user input
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                // Handle menu choices
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You selected Option 1");
                        break;
                    case 2:
                        Console.WriteLine("You selected Option 2");
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            else
            {
                // Invalid input handling
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (choice != 3);
    }
}