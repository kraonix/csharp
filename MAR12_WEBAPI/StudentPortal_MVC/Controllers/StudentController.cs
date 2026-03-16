using Microsoft.AspNetCore.Mvc;
using StudentPortal_MVC.Services;

namespace StudentPortal_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApiService _api;

        public StudentController(ApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _api.GetStudents();
            return View(students);
        }
    }
}