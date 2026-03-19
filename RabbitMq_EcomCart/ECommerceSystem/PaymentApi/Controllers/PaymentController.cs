using Microsoft.AspNetCore.Mvc;
using PaymentApi.Services;
using Shared.Models;

namespace PaymentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly InMemoryPaymentStore _paymentStore;
    private readonly ILogger<PaymentController> _logger;

    public PaymentController(InMemoryPaymentStore paymentStore, ILogger<PaymentController> logger)
    {
        _paymentStore = paymentStore;
        _logger = logger;
    }

    /// <summary>Get all processed payments</summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<PaymentRecord>), StatusCodes.Status200OK)]
    public ActionResult<List<PaymentRecord>> GetAll()
    {
        var payments = _paymentStore.GetAll();
        _logger.LogInformation("Returning {Count} payment records.", payments.Count);
        return Ok(payments);
    }

    /// <summary>Get payment by order ID</summary>
    [HttpGet("{orderId}")]
    [ProducesResponseType(typeof(PaymentRecord), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<PaymentRecord> GetByOrderId(string orderId)
    {
        var record = _paymentStore.GetAll().FirstOrDefault(p => p.OrderId == orderId);
        if (record == null)
            return NotFound(new { Message = $"No payment record found for order '{orderId}'." });
        return Ok(record);
    }
}
