using PaymentServiceAPI.Models;

namespace PaymentServiceAPI.Repositories;

public interface IPaymentRepository
{
    List<Payment> GetAll();

    Payment GetById(int id);

    List<Payment> GetByOrder(int orderId);

    void Add(Payment payment);

    void Update(Payment payment);

    void Delete(int id);
}