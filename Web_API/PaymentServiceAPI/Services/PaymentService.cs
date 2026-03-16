using PaymentServiceAPI.Models;
using PaymentServiceAPI.Repositories;

namespace PaymentServiceAPI.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public List<Payment> GetPayments()
    {
        return _repository.GetAll();
    }

    public Payment GetPayment(int id)
    {
        return _repository.GetById(id);
    }

    public List<Payment> GetPaymentsByOrder(int orderId)
    {
        return _repository.GetByOrder(orderId);
    }

    public void ProcessPayment(Payment payment)
    {
        _repository.Add(payment);
    }

    public void UpdatePayment(Payment payment)
    {
        _repository.Update(payment);
    }

    public void DeletePayment(int id)
    {
        _repository.Delete(id);
    }
}