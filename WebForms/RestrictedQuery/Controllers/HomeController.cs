using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestrictedQuery.Models;

namespace RestrictedQuery.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Echo(string q, string ans)
    {
        return Content($"You sent q = {q}");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
