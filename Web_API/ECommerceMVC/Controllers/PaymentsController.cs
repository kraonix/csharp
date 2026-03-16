using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Models;
using ECommerceMVC.Services;

namespace ECommerceMVC.Controllers;

public class PaymentsController : Controller
{
    private readonly ApiService _api;

    public PaymentsController(ApiService api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var payments = await _api.GetAsync<Payment>("http://localhost:7000/gateway/payments");
        return View(payments);
    }
}
