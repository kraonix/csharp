using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Models;

[Authorize(Roles = "Student")]
public class StudentController : Controller
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var totalCourses = _context.Enrollments
            .Count(e => e.StudentId == studentId);

        var completedCourses = _context.Enrollments
            .Count(e => e.StudentId == studentId && e.Grade != null);

        ViewBag.TotalCourses = totalCourses;
        ViewBag.CompletedCourses = completedCourses;

        return View();
    }

    public IActionResult Courses()
    {
        var courses = _context.Courses.ToList();
        return View(courses);
    }

    [HttpPost]
    public IActionResult Enroll(int courseId)
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // prevent duplicate enrollment
        var exists = _context.Enrollments
            .Any(e => e.StudentId == studentId && e.CourseId == courseId);

        if (!exists)
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        return RedirectToAction("MyCourses");
    }

    public IActionResult MyCourses()
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var myCourses = _context.Enrollments
            .Include(e => e.Course)
            .Where(e => e.StudentId == studentId)
            .ToList();

        return View(myCourses);
    }

    public IActionResult Grades()
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var grades = _context.Enrollments
            .Include(e => e.Course)
            .Where(e => e.StudentId == studentId)
            .ToList();

        return View(grades);
    }
}