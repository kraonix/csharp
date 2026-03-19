using Shared.Models;
using System.Collections.Concurrent;

namespace PaymentApi.Services;

public class InMemoryPaymentStore
{
    private readonly List<PaymentRecord> _payments = new();
    private readonly object _lock = new();

    public void RecordPayment(PaymentRecord record)
    {
        lock (_lock)
        {
            _payments.Add(record);
        }
    }

    public List<PaymentRecord> GetAll()
    {
        lock (_lock)
        {
            return _payments.ToList();
        }
    }
}
