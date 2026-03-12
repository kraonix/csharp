using System; // Console

namespace ItTechGenie.M1.GenericsDelegates.Q9
{
    public class Program
    {
        public static void Main()
        {
            var monitor = new ThresholdMonitor<int>(threshold: 80);              // threshold 80

            monitor.ThresholdReached += v => Console.WriteLine($"ALERT: {v}");    // subscribe

            monitor.AddSample(60);                                               // no alert
            monitor.AddSample(90);                                               // should alert
        }
    }

    public class ThresholdMonitor<T> where T : IComparable<T>
    {
        private readonly T _threshold;                                           // threshold value
        public event Action<T>? ThresholdReached;                                // event callback

        public ThresholdMonitor(T threshold)
        {
            _threshold = threshold;                                              // store threshold
        }

        // ✅ TODO: Student must implement only this method
        public void AddSample(T value)
        {
            // TODO:
            // 1) Compare value with _threshold using CompareTo
            // 2) If value >= _threshold, invoke ThresholdReached (if not null)
            if (value.CompareTo(_threshold) >= 0)
            {
                ThresholdReached?.Invoke(value);
            }
        }
    }
}