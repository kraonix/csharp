using Microsoft.AspNetCore.Mvc;
using StudentPortal_MVC.Models;
using StudentPortal_MVC.Services;

namespace StudentPortal_MVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApiService _api;

        public CourseController(ApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _api.GetCourses();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            await _api.CreateCourse(course);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}