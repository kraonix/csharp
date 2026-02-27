using DbFirstDemo.Data;
using DbFirstDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbFirstDemo.Controllers
{
    public class EmployeeManagementController : Controller
    {
        private readonly EmployeeManagementContext _context;

        public EmployeeManagementController(EmployeeManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search, string sortOrder)
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .Include(e => e.EmployeeProjects)
                    .ThenInclude(ep => ep.Project)
                .AsQueryable();

            // Search
            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(e =>
                    (e.FirstName ?? "").Contains(search) ||
                    (e.LastName ?? "").Contains(search));
            }

            // Sort
            employees = sortOrder switch
            {
                "salary_asc" => employees.OrderBy(e => e.Salary),
                "salary_desc" => employees.OrderByDescending(e => e.Salary),
                _ => employees.OrderBy(e => e.EmployeeID)
            };

            ViewBag.CurrentSearch = search;
            ViewBag.CurrentSort = sortOrder;

            return View(await employees.AsNoTracking().ToListAsync());
        }
    }
}