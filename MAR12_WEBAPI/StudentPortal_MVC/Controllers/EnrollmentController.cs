using Microsoft.AspNetCore.Mvc;
using StudentPortal_MVC.Services;

namespace StudentPortal_MVC.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApiService _api;

        public EnrollmentController(ApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var enrollments = await _api.GetEnrollments();
            return View(enrollments);
        }
    }
}