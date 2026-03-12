using System;
using System.ComponentModel; // Console, Exception

namespace ItTechGenie.M1.GenericsDelegates.Q10
{
    public class Program
    {
        public static void Main()
        {
            int attempts = 0;                                                    // track attempts

            // A sample operation that fails twice, succeeds third time.
            int result = RetryUtil.ExecuteWithRetry(
                action: () =>
                {
                    attempts++;                                                  // increment
                    if (attempts < 3) throw new InvalidOperationException("Temporary failure"); // simulate failure
                    return 200;                                                  // success value
                },
                maxAttempts: 5,                                                  // max tries
                shouldRetry: ex => ex is InvalidOperationException                // retry only for this type
            );

            Console.WriteLine($"Result = {result}");                              // print
        }
    }

    public static class RetryUtil
    {
        // ✅ TODO: Student must implement only this method
        public static T ExecuteWithRetry<T>(Func<T> action, int maxAttempts, Func<Exception, bool> shouldRetry)
        {
            // TODO:
            // 1) Validate inputs (action, shouldRetry, maxAttempts >= 1)
            // 2) Loop attempts:
            //    - try: return action()
            //    - catch Exception ex:
            //        - if attempts reached OR shouldRetry(ex) is false => throw
            //        - else continue to next attempt

            if (action == null) throw new ArgumentNullException(nameof(action));
            if (shouldRetry == null) throw new ArgumentNullException(nameof(shouldRetry));
            if (maxAttempts < 1) throw new ArgumentException("maxAttempts must be >= 1");

            int attempt = 0;

            while (true)
            {
                try
                {
                    attempt++;
                    return action();
                }
                catch (Exception ex)
                {
                    if (attempt >= maxAttempts || !shouldRetry(ex))
                    {
                        throw;
                    }
                }
            }
        }
    }
}
