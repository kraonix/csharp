using System;
using System.Collections.Generic;

public class RateLimiter
{
    private readonly int _maxRequests = 5;
    private readonly TimeSpan _window = TimeSpan.FromSeconds(10);

    // clientId -> timestamps of requests
    private readonly Dictionary<string, Queue<DateTime>> _requests 
        = new Dictionary<string, Queue<DateTime>>();

    private readonly object _lock = new object();

    public bool AllowRequest(string clientId, DateTime now)
    {
        lock (_lock)
        {
            if (!_requests.ContainsKey(clientId))
            {
                _requests[clientId] = new Queue<DateTime>();
            }

            var queue = _requests[clientId];

            // Remove old timestamps outside sliding window
            while (queue.Count > 0 && 
                   queue.Peek() <= now - _window)
            {
                queue.Dequeue();
            }

            if (queue.Count >= _maxRequests)
            {
                return false; // limit reached
            }

            queue.Enqueue(now);
            return true;
        }
    }
}
