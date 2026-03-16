using Microsoft.AspNetCore.Mvc;
using CartServiceAPI.Models;
using CartServiceAPI.Services;

namespace CartServiceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _service;

    public CartController(ICartService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetCart()
    {
        return Ok(_service.GetCart());
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserCart(int userId)
    {
        return Ok(_service.GetUserCart(userId));
    }

    [HttpPost]
    public IActionResult AddToCart(CartItem item)
    {
        _service.AddToCart(item);
        return Ok("Item added to cart");
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveFromCart(int id)
    {
        _service.RemoveFromCart(id);
        return Ok("Item removed from cart");
    }
}