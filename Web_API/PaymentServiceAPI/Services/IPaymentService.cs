using PaymentServiceAPI.Models;

namespace PaymentServiceAPI.Services;

public interface IPaymentService
{
    List<Payment> GetPayments();

    Payment GetPayment(int id);

    List<Payment> GetPaymentsByOrder(int orderId);

    void ProcessPayment(Payment payment);

    void UpdatePayment(Payment payment);

    void DeletePayment(int id);
}