using System;

namespace ShapeArea
{
    // Interface defining Area behavior
    interface IArea
    {
        double GetArea();
    }

    // Abstract base class for all shapes
    abstract class Shape : IArea
    {
        // Abstract method to calculate area
        public abstract double GetArea();
    }

    // Circle class
    class Circle : Shape
    {
        double radius;

        // Constructor
        public Circle(double radius)
        {
            this.radius = radius;
        }

        // Override area calculation
        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }

    // Rectangle class
    class Rectangle : Shape
    {
        double width;
        double height;

        // Constructor
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        // Override area calculation
        public override double GetArea()
        {
            return width * height;
        }
    }

    // Triangle class
    class Triangle : Shape
    {
        double baseValue;
        double height;

        // Constructor
        public Triangle(double baseValue, double height)
        {
            this.baseValue = baseValue;
            this.height = height;
        }

        // Override area calculation
        public override double GetArea()
        {
            return 0.5 * baseValue * height;
        }
    }

    public class Program
    {
        // User-defined method to compute total area of shapes
        static double ComputeTotalArea(string[] shapes)
        {
            double totalArea = 0;

            // Check if input array is not null
            if (shapes != null)
            {
                // Loop through each shape description
                for (int i = 0; i < shapes.Length; i++)
                {
                    string[] parts = shapes[i].Split(' ');
                    Shape shape = null;

                    // Identify shape type
                    if (parts[0] == "C")
                    {
                        // Circle: C r
                        double r = double.Parse(parts[1]);
                        shape = new Circle(r);
                    }
                    else if (parts[0] == "R")
                    {
                        // Rectangle: R w h
                        double w = double.Parse(parts[1]);
                        double h = double.Parse(parts[2]);
                        shape = new Rectangle(w, h);
                    }
                    else if (parts[0] == "T")
                    {
                        // Triangle: T b h
                        double b = double.Parse(parts[1]);
                        double h = double.Parse(parts[2]);
                        shape = new Triangle(b, h);
                    }

                    // Add area using polymorphism
                    if (shape != null)
                    {
                        totalArea += shape.GetArea();
                    }
                }
            }

            // Round result to 2 decimals (AwayFromZero)
            return Math.Round(totalArea, 2, MidpointRounding.AwayFromZero);
        }

        // Main method – program execution starts here
        static void Main()
        {
            // Ask user for number of shapes
            Console.WriteLine("Enter number of shapes");
            int n = int.Parse(Console.ReadLine());

            // Declare shapes array
            string[] shapes = new string[n];

            // Read shape details
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter shape {i + 1}");
                shapes[i] = Console.ReadLine();
            }

            // Compute total area
            double result = ComputeTotalArea(shapes);

            // Display result
            Console.WriteLine("Total Area: " + result);
        }
    }
}
