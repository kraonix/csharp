using CartApi.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace CartApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly InMemoryCartStore _cartStore;
    private readonly ILogger<CartController> _logger;

    public CartController(InMemoryCartStore cartStore, ILogger<CartController> logger)
    {
        _cartStore = cartStore;
        _logger = logger;
    }

    /// <summary>Get all cart items</summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
    public ActionResult<List<CartItem>> GetAll()
    {
        var items = _cartStore.GetAll();
        _logger.LogInformation("Returning {Count} cart items. Total: ₹{Total}", items.Count, _cartStore.GetTotal());
        return Ok(items);
    }

    /// <summary>Get cart total</summary>
    [HttpGet("total")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public ActionResult GetTotal()
    {
        return Ok(new { Total = _cartStore.GetTotal(), ItemCount = _cartStore.GetAll().Count });
    }

    /// <summary>Clear the cart</summary>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Clear()
    {
        _cartStore.Clear();
        _logger.LogInformation("Cart cleared.");
        return NoContent();
    }
}
