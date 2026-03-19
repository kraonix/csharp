using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Models;

[Authorize(Roles = "Faculty")]
public class FacultyController : Controller
{
    private readonly AppDbContext _context;

    public FacultyController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var facultyId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var totalCourses = _context.Courses
            .Count(c => c.FacultyId == facultyId);

        var totalStudents = _context.Enrollments
            .Where(e => e.Course.FacultyId == facultyId)
            .Select(e => e.StudentId)
            .Distinct()
            .Count();

        ViewBag.Courses = totalCourses;
        ViewBag.Students = totalStudents;

        return View();
    }

    public IActionResult MyCourses()
    {
        var facultyId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var courses = _context.Courses
            .Where(c => c.FacultyId == facultyId)
            .ToList();

        return View(courses);
    }

    public IActionResult CreateCourse()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateCourse(Course course)
    {
        var facultyId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        course.FacultyId = facultyId;

        _context.Courses.Add(course);
        _context.SaveChanges();

        return RedirectToAction("MyCourses");
    }

    public IActionResult Students(int courseId)
    {
        var students = _context.Enrollments
            .Include(e => e.Student)
            .Where(e => e.CourseId == courseId)
            .ToList();

        return View(students);
    }

    [HttpPost]
    public IActionResult AssignGrade(int enrollmentId, string grade)
    {
        var enrollment = _context.Enrollments.Find(enrollmentId);

        if (enrollment != null)
        {
            enrollment.Grade = grade;
            _context.SaveChanges();
        }

        return RedirectToAction("MyCourses");
    }
}