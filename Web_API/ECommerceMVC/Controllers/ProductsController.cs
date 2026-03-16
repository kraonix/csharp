using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Models;
using ECommerceMVC.Services;

namespace ECommerceMVC.Controllers;

public class ProductsController : Controller
{
    private readonly ApiService _api;

    public ProductsController(ApiService api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _api.GetAsync<Product>("http://localhost:7000/gateway/products");

        return View(products);
    }
}