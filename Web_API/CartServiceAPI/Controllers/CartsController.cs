using Microsoft.AspNetCore.Mvc;
using CartServiceAPI.Models;
using CartServiceAPI.Services;

namespace CartServiceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<CartItem>> GetCart(int userId)
    {
        var cart = _cartService.GetUserCart(userId);
        return Ok(cart);
    }

    [HttpPost]
    public ActionResult AddToCart([FromBody] CartItem item)
    {
        _cartService.AddToCart(item);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult RemoveFromCart(int id)
    {
        _cartService.RemoveFromCart(id);
        return NoContent();
    }
}
