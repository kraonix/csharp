using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class PaymentGateway
{
    private readonly Queue<DateTime> _failureTimestamps = new();
    private readonly object _lock = new();

    private bool _circuitOpen = false;
    private DateTime _circuitOpenedAt;

    private readonly TimeSpan _failureWindow = TimeSpan.FromMinutes(1);
    private readonly TimeSpan _circuitDuration = TimeSpan.FromSeconds(30);

    public async Task<PaymentResult> ProcessPaymentAsync(
        PaymentRequest request,
        CancellationToken cancellationToken)
    {
        // Check circuit
        if (IsCircuitOpen())
        {
            return new PaymentResult
            {
                Success = false,
                Message = "Circuit is open. Try later."
            };
        }

        int retryCount = 0;

        while (retryCount < 3)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                // Simulate external API call
                var result = await CallExternalGatewayAsync(request, cancellationToken);

                ResetFailures();
                return result;
            }
            catch (TimeoutException)
            {
                retryCount++;
                RegisterFailure();

                if (retryCount >= 3)
                    throw; // rethrow after max retries
            }
        }

        return new PaymentResult
        {
            Success = false,
            Message = "Payment failed after retries."
        };
    }

    private bool IsCircuitOpen()
    {
        lock (_lock)
        {
            if (!_circuitOpen)
                return false;

            if (DateTime.UtcNow - _circuitOpenedAt > _circuitDuration)
            {
                _circuitOpen = false; // Close circuit after cooldown
                return false;
            }

            return true;
        }
    }

    private void RegisterFailure()
    {
        lock (_lock)
        {
            var now = DateTime.UtcNow;

            _failureTimestamps.Enqueue(now);

            // Remove failures older than 1 minute
            while (_failureTimestamps.Count > 0 &&
                   _failureTimestamps.Peek() <= now - _failureWindow)
            {
                _failureTimestamps.Dequeue();
            }

            if (_failureTimestamps.Count >= 5)
            {
                _circuitOpen = true;
                _circuitOpenedAt = now;
            }
        }
    }

    private void ResetFailures()
    {
        lock (_lock)
        {
            _failureTimestamps.Clear();
        }
    }

    // Simulated external call
    private async Task<PaymentResult> CallExternalGatewayAsync(
        PaymentRequest request,
        CancellationToken cancellationToken)
    {
        await Task.Delay(500, cancellationToken);

        // Randomly simulate timeout
        if (new Random().Next(0, 2) == 0)
            throw new TimeoutException("Gateway timeout");

        return new PaymentResult
        {
            Success = true,
            Message = "Payment processed successfully"
        };
    }
}
