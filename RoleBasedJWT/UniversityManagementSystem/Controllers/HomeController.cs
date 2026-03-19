using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace UniversityManagementSystem.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var token = Request.Cookies["jwt"];

        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Auth");
        }

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var role = jwtToken.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            return role switch
            {
                "Admin" => RedirectToAction("Dashboard", "Admin"),
                "Faculty" => RedirectToAction("Dashboard", "Faculty"),
                "Student" => RedirectToAction("Dashboard", "Student"),
                _ => RedirectToAction("Login", "Auth")
            };
        }
        catch
        {
            return RedirectToAction("Login", "Auth");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Landing()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel 
        { 
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
        });
    }
}