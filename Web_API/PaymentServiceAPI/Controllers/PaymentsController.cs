using Microsoft.AspNetCore.Mvc;
using PaymentServiceAPI.Models;
using PaymentServiceAPI.Services;

namespace PaymentServiceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Payment>> Get()
    {
        var payments = _paymentService.GetPayments();
        return Ok(payments);
    }

    [HttpGet("{id}")]
    public ActionResult<Payment> Get(int id)
    {
        var payment = _paymentService.GetPayment(id);
        if (payment == null)
            return NotFound();
            
        return Ok(payment);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Payment payment)
    {
        _paymentService.ProcessPayment(payment);
        return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Payment payment)
    {
        if (id != payment.Id)
            return BadRequest();

        var existingPayment = _paymentService.GetPayment(id);
        if (existingPayment == null)
            return NotFound();

        _paymentService.UpdatePayment(payment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingPayment = _paymentService.GetPayment(id);
        if (existingPayment == null)
            return NotFound();

        _paymentService.DeletePayment(id);
        return NoContent();
    }
}