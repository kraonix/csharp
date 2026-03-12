using System; // Console
using System.Collections.Generic; // List<T>, IEnumerable<T>

namespace ItTechGenie.M1.GenericsDelegates.Q7
{
    public class Program
    {
        public static void Main()
        {
            var ints = new List<int> { 1, 2, 3, 4 };                 // integer list
            Console.WriteLine(SumUtil.Sum(ints));                    // expected 10

            var decimals = new List<decimal> { 1.5m, 2.5m, 3.0m };    // decimal list
            Console.WriteLine(SumUtil.Sum(decimals));                // expected 7.0
        }
    }

    public static class SumUtil
    {
        // Note: This constraint allows only value types.
        public static T Sum<T>(IEnumerable<T> values) where T : struct
        {
            // ✅ TODO: Student must implement only this method
            // Hint (pattern):
            //   dynamic total = default(T);
            //   foreach (var v in values) total += (dynamic)v;
            //   return (T)total;
            dynamic result = default(T);
            foreach(T i in values)
            {
                result += i;
            }

            return result;
        }
    }
}