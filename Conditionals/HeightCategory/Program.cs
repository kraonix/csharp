class HeightCategory
{
    static void Main(string[] args)
    {
        // Input height from user
        Console.WriteLine("Enter your height in centimeters:");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int height))
        {
            if (height < 150)
            {
                Console.WriteLine("Dwarf");
            }
            else if (height >= 150 && height <= 165)
            {
                Console.WriteLine("Average");
            }
            else if(height > 165 && height <= 190)
            {
                Console.WriteLine("Tall");
            }
            else
            {
                Console.WriteLine("Abnormal");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}