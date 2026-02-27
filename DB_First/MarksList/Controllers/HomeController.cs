using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarksList.Models;
using MarksList.Data;

namespace MarksList.Controllers;

public class HomeController : Controller
{
    private readonly MarksContext _context;

    public HomeController(MarksContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var allMarks = await _context.Marks.ToListAsync();

        double avgMarks1 = 0;
        double avgMarks2 = 0;

        if (allMarks.Any())
        {
            avgMarks1 = Math.Round(allMarks.Average(m => m.Marks1), 2);
            avgMarks2 = Math.Round(allMarks.Average(m => m.Marks2), 2);
        }

        var vm = new MarksDashboardViewModel
        {
            AvgMarks1 = avgMarks1,
            AvgMarks2 = avgMarks2,
            AllMarks = allMarks
        };

        return View(vm);
    }

    public IActionResult Privacy()
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