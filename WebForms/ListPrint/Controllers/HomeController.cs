using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ListPrint.Models;

namespace ListPrint.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        ViewBag.MyVariable = "India, China, USA";
        string value = ViewBag.MyVariable as string;

        ViewBag.myVariableList = value?.Split(',');

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
