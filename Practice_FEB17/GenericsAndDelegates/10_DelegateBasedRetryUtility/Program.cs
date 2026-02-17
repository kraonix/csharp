using System;

public class Program
{
    private static int _tries = 0;                    // Simulation counter

    public static void Main()
    {
        // A function that fails twice, then succeeds
        int result = ExecuteWithRetry(() =>
        {
            _tries++;
            if (_tries <= 2) throw new InvalidOperationException("Temporary failure");
            return 999;
        }, maxAttempts: 3);

        Console.WriteLine(result);                    // Expected: 999
    }

    // ✅ TODO: Students implement only this function
    public static T ExecuteWithRetry<T>(Func<T> work, int maxAttempts)
    {
        // TODO:
        // 1) Validate inputs
        // 2) Try executing work
        // 3) If exception occurs and attempts remain, retry
        // 4) If attempts exhausted, throw last exception
        Exception? lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                return work(); // Success => immediately return
            }
            catch (Exception ex)
            {
                lastException = ex;

                if (attempt == maxAttempts)
                    throw; // No attempts left => rethrow last exception
            }
        }

        // This line is technically unreachable, but required for compilation
        throw lastException!;
    }
}