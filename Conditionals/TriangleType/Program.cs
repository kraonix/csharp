class TriangleType
{
    /// <summary>
    /// Program for determining the type of triangle.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        // Read the lengths of the sides of the triangle
        Console.WriteLine("Enter the lengths of the three sides of the triangle:");
        Console.Write("Side A: ");
        double sideA = Convert.ToDouble(Console.ReadLine());
        Console.Write("Side B: ");
        double sideB = Convert.ToDouble(Console.ReadLine());
        Console.Write("Side C: ");
        double sideC = Convert.ToDouble(Console.ReadLine());

        // Determine the type of triangle
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            // Invalid side lengths
            Console.WriteLine("Invalid side lengths. All sides must be positive.");
        }
        else if (sideA == sideB && sideB == sideC)
        {
            // Equilateral triangle
            Console.WriteLine("The triangle is equilateral.");
        }
        else if (sideA == sideB || sideB == sideC || sideA == sideC)
        {
            // Isosceles triangle
            Console.WriteLine("The triangle is isosceles.");
        }
        else
        {
            // Scalene triangle
            Console.WriteLine("The triangle is scalene.");
        }
    }
}