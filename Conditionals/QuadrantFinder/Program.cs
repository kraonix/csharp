class QuadrantFinder
{
    /// <summary>
    /// Program for finding the quadrant of a point.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // Input coordinates
        Console.WriteLine("Enter the X coordinate:");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the Y coordinate:");
        double y = Convert.ToDouble(Console.ReadLine());


        // Determine the quadrant or axis
        if (x > 0 && y > 0)
        {
            Console.WriteLine("The point is in Quadrant 1.");
        }
        else if (x < 0 && y > 0)
        {
            Console.WriteLine("The point is in Quadrant 2.");
        }
        else if (x < 0 && y < 0)
        {
            Console.WriteLine("The point is in Quadrant 3.");
        }
        else if (x > 0 && y < 0)
        {
            Console.WriteLine("The point is in Quadrant 4.");
        }
        else if (x == 0 && y != 0)
        {
            Console.WriteLine("The point is on the Y axis.");
        }
        else if (y == 0 && x != 0)
        {
            Console.WriteLine("The point is on the X axis.");
        }
        else
        {
            Console.WriteLine("The point is at the origin.");
        }
    }
}