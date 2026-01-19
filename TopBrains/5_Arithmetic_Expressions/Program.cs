using System;
namespace ArithmeticExpression
{
    public class Program
    {
        // Method to evaluate the arithmetic expression
        public static string CalculateOperation(string expression)
        {
            // Split expression by spaces
            string[] parts = expression.Split(' ');
            // Validate expression format: must be exactly "a op b"
            if (parts.Length != 3)
                return "Error:InvalidExpression";
            int a, b;
            // Validate whether a and b are integers
            if (!int.TryParse(parts[0], out a) || !int.TryParse(parts[2], out b))
                return "Error:InvalidNumber";
            string op = parts[1];

            // Perform operation based on operator
            switch (op)
            {
                case "+":
                    return (a + b).ToString();

                case "-":
                    return (a - b).ToString();

                case "*":
                    return (a * b).ToString();

                case "/":
                    // Check divide by zero
                    if (b == 0)
                        return "Error:DivideByZero";
                    return (a / b).ToString();

                default:
                    // Invalid operator
                    return "Error:UnknownOperator";
            }
        }
        static void Main()
        {
            // Read input expression
            Console.WriteLine("Enter the expression in format (a op b): ");
            string expression = Console.ReadLine()!;
            // Evaluate expression
            string result = CalculateOperation(expression);
            // Print result
            Console.WriteLine(result);
        }
    }
}
