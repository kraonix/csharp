using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Models;
using ECommerceMVC.Services;

namespace ECommerceMVC.Controllers;

public class CartController : Controller
{
    private readonly ApiService _api;
    // Hardcoded user id for demo, would come from auth in real app
    private const int DemoUserId = 1;

    public CartController(ApiService api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _api.GetAsync<CartItem>($"http://localhost:7000/gateway/cart/{DemoUserId}");
        return View(items);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
    {
        var item = new CartItem
        {
            UserId = DemoUserId,
            ProductId = productId,
            Quantity = quantity
        };
        await _api.PostAsync("http://localhost:7000/gateway/cart", item);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        await _api.DeleteAsync($"http://localhost:7000/gateway/cart/{id}");
        return RedirectToAction("Index");
    }
}
