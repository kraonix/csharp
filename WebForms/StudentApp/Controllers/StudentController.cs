using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using System.Collections.Generic;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }
    }
}