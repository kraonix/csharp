using ECommerceMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace ECommerceMVC.Controllers;

public class HomeController : Controller
{
    private readonly ProductCatalog _catalog;
    private readonly RabbitMqProducerService _producer;
    private readonly InMemoryCartStore _cartStore;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ProductCatalog catalog, RabbitMqProducerService producer,
        InMemoryCartStore cartStore, ILogger<HomeController> logger)
    {
        _catalog = catalog;
        _producer = producer;
        _cartStore = cartStore;
        _logger = logger;
    }

    // GET /
    public IActionResult Index()
    {
        ViewBag.CartCount = _cartStore.GetAll().Count;
        return View(_catalog.Products);
    }

    // POST /Home/AddToCart
    [HttpPost]
    public IActionResult AddToCart(int productId)
    {
        var product = _catalog.GetById(productId);
        if (product == null)
        {
            TempData["Error"] = "Product not found.";
            return RedirectToAction(nameof(Index));
        }

        // Publish message to cart_queue via RabbitMQ
        var message = new CartMessage
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Price = product.Price
        };
        _producer.PublishToQueue(RabbitMqProducerService.CartQueue, message);

        // Also update local cart store for display
        _cartStore.AddOrUpdate(new CartItem
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Price = product.Price,
            Quantity = 1
        });

        _logger.LogInformation("Added product {ProductId} ({ProductName}) to cart via RabbitMQ.", product.Id, product.Name);
        TempData["Success"] = $"'{product.Name}' added to cart!";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Error()
    {
        return View();
    }
}
