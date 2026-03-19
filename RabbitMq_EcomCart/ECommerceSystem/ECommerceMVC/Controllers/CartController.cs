using ECommerceMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace ECommerceMVC.Controllers;

public class CartController : Controller
{
    private readonly InMemoryCartStore _cartStore;
    private readonly RabbitMqProducerService _producer;
    private readonly ILogger<CartController> _logger;

    public CartController(InMemoryCartStore cartStore, RabbitMqProducerService producer,
        ILogger<CartController> logger)
    {
        _cartStore = cartStore;
        _producer = producer;
        _logger = logger;
    }

    // GET /Cart
    public IActionResult Index()
    {
        var items = _cartStore.GetAll();
        ViewBag.Total = _cartStore.GetTotal();
        ViewBag.CartCount = items.Count;
        return View(items);
    }

    // POST /Cart/Pay
    [HttpPost]
    public IActionResult Pay()
    {
        var items = _cartStore.GetAll();
        if (!items.Any())
        {
            TempData["Error"] = "Your cart is empty. Add some products first!";
            return RedirectToAction(nameof(Index));
        }

        var orderId = Guid.NewGuid().ToString("N")[..8].ToUpper();
        var total = _cartStore.GetTotal();

        // Publish to payment_queue via RabbitMQ
        var paymentMessage = new PaymentMessage
        {
            OrderId = orderId,
            TotalAmount = total,
            Items = items
        };
        _producer.PublishToQueue(RabbitMqProducerService.PaymentQueue, paymentMessage);

        _logger.LogInformation("Payment message published for Order {OrderId}. Total: ₹{Total}", orderId, total);

        // Clear cart after payment
        _cartStore.Clear();

        TempData["OrderId"] = orderId;
        TempData["Total"] = total.ToString("F2");
        TempData["ItemCount"] = items.Count.ToString();
        return RedirectToAction(nameof(PaymentSuccess));
    }

    // GET /Cart/PaymentSuccess
    public IActionResult PaymentSuccess()
    {
        ViewBag.OrderId = TempData["OrderId"];
        ViewBag.Total = TempData["Total"];
        ViewBag.ItemCount = TempData["ItemCount"];
        ViewBag.CartCount = 0;
        return View();
    }
}
