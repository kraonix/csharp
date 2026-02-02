using System;

namespace Array
{
    // Program demonstrates summing integer values from an object array
    class Program
    {
        // SumIntegers: iterates over an object array and adds up any ints found
        static int SumIntegers(object[] values)
        {
            int sum = 0; // accumulator for integer sum

            // iterate through each element in the array
            foreach (var value in values)
            {
                // pattern-match to int: if value is an int, assign it to x
                if (value is int x)
                {
                    sum += x; // add the integer to the sum
                }
            }


            return sum; // return the computed sum
        }

        static void Main()
        {
            // an object array containing different types; only the integer 10 will be summed
            object[] values = { 10, "hello,true,null,20,5.5,3" };

            int sum = SumIntegers(values); // compute sum of integers in the array

            // print the result to the console
            Console.WriteLine("Sum of integers: " + sum);
        }
    }
}