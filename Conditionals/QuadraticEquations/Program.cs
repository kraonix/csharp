class QuadraticEquations
{
    public static void Main(string[] args)
    {
        // Coefficients of the quadratic equation ax^2 + bx + c = 0
        Console.WriteLine("Enter coefficients a, b and c:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        // Calculate the discriminant
        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            // Two real and distinct roots
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Roots are real and different. Root1: {root1}, Root2: {root2}");
        }
        else if (discriminant == 0)
        {
            // One real root
            double root = -b / (2 * a);
            Console.WriteLine($"Roots are real and the same. Root: {root}");
        }
        else
        {
            // Complex roots
            double realPart = -b / (2 * a);
            double imaginaryPart = Math.Sqrt(-discriminant) / (2 * a);
            Console.WriteLine($"Roots are complex. Root1: {realPart} + {imaginaryPart}i, Root2: {realPart} - {imaginaryPart}i");
        }
    }
}