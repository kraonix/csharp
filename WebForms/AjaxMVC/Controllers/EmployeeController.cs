using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AjaxMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = new List<object>
            {
                new { Id = 1, Name = "Sachin", Role = "Backend Dev" },
                new { Id = 2, Name = "Rahul", Role = "Frontend Dev" },
                new { Id = 3, Name = "Anjali", Role = "QA Engineer" }
            };

            return Json(employees);
        }
    }
}