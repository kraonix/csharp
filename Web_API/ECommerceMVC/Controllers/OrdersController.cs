using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Models;
using ECommerceMVC.Services;

namespace ECommerceMVC.Controllers;

public class OrdersController : Controller
{
    private readonly ApiService _api;

    public OrdersController(ApiService api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _api.GetAsync<Order>("http://localhost:7000/gateway/orders");
        return View(orders);
    }
}
