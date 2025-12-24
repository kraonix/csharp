using CommonLib;

namespace MathsLib
{

    /// <summary>
    /// Provides basic algebraic operations.
    /// </summary>
    public class Algebra
    {
        // Performs addition of two integers.
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Performs subtraction of two integers.
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        // Performs multiplication of two integers.
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        // Performs division of two integers.
        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }
            return (double)a / b;
        }

    }
}