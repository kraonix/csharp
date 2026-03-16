using PaymentServiceAPI.Models;

namespace PaymentServiceAPI.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private static List<Payment> payments = new List<Payment>()
    {
        new Payment
        {
            Id = 1,
            OrderId = 1,
            Amount = 60000,
            Method = "UPI",
            Status = "Success",
            PaymentDate = DateTime.Now
        },
        new Payment
        {
            Id = 2,
            OrderId = 2,
            Amount = 30000,
            Method = "Card",
            Status = "Success",
            PaymentDate = DateTime.Now
        }
    };

    public List<Payment> GetAll()
    {
        return payments;
    }

    public Payment GetById(int id)
    {
        return payments.FirstOrDefault(p => p.Id == id);
    }

    public List<Payment> GetByOrder(int orderId)
    {
        return payments.Where(p => p.OrderId == orderId).ToList();
    }

    public void Add(Payment payment)
    {
        payment.Id = payments.Max(p => p.Id) + 1;
        payment.PaymentDate = DateTime.Now;
        payment.Status = "Success";

        payments.Add(payment);
    }

    public void Update(Payment payment)
    {
        var existingPayment = payments.FirstOrDefault(p => p.Id == payment.Id);
        if (existingPayment != null)
        {
            existingPayment.Amount = payment.Amount;
            existingPayment.Method = payment.Method;
            existingPayment.Status = payment.Status;
        }
    }

    public void Delete(int id)
    {
        var payment = payments.FirstOrDefault(p => p.Id == id);
        if (payment != null)
        {
            payments.Remove(payment);
        }
    }
}