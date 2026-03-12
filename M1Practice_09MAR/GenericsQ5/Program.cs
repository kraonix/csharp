using System; // Console
using System.Collections.Generic; // List<T>, IEnumerable<T>

namespace ItTechGenie.M1.GenericsDelegates.Q5
{
    public class Program
    {
        public static void Main()
        {
            var numbers = new List<int> { 5, 10, 15, 20, 25 };                // sample data
            var filtered = FilterUtil.Filter(numbers, n => n >= 15);          // keep >= 15

            foreach (var n in filtered)                                       // print result
            {
                Console.WriteLine(n);                                         // output each
            }
        }
    }

    public static class FilterUtil
    {
        // ✅ TODO: Student must implement only this method
        public static List<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            // TODO: Validate inputs, iterate items, apply predicate, build output list
            List<T> result = new();
            foreach(var i in items)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}