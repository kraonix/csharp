using CourseManagementWebApi.Data;
using CourseManagementWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementWebApi.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
   // In-memory mock data storage
   private static List<Course> _courses = new List<Course>
   {
      new Course { id = 1, title = "Introduction to C#", description = "Learn the basics of C# programming language", duration = 10 },
      new Course { id = 2, title = "Angular Fundamentals", description = "Master Angular framework for building modern web applications", duration = 15 },
      new Course { id = 3, title = "ASP.NET Core Web API", description = "Build RESTful APIs with ASP.NET Core", duration = 12 }
   };
   private static int _nextId = 4;

   [HttpGet]
   public IActionResult GetCourses()
   {
      return Ok(_courses);
   }

   [HttpGet("test")]
   public IActionResult Test()
   {
      return Ok(new { message = "Backend is working!", timestamp = DateTime.Now });
   }

   [HttpGet("{id}")]
   public IActionResult GetCourse(int id)
   {
      var course = _courses.FirstOrDefault(c => c.id == id);
      if (course == null)
      {
         return NotFound("Course not found");
      }
      return Ok(course);
   }

   [HttpPost]
   public IActionResult AddCourse(Course course)
   {
      course.id = _nextId++;
      _courses.Add(course);
      return Ok(course);
   }

   [HttpPut("{id}")]
   public IActionResult UpdateCourse(int id, Course course)
   {
      if (id != course.id)
      {
         return BadRequest("Id mismatch");
      }

      var existingCourse = _courses.FirstOrDefault(c => c.id == id);

      if (existingCourse == null)
      {
         return NotFound("Course not found");
      }

      existingCourse.title = course.title;
      existingCourse.description = course.description;
      existingCourse.duration = course.duration;

      return Ok(existingCourse);
   }

   [HttpDelete("{id}")]
   public IActionResult DeleteCourse(int id)
   {
      var existingCourse = _courses.FirstOrDefault(c => c.id == id);

      if (existingCourse == null)
      {
         return NotFound("Course not found");
      }

      _courses.Remove(existingCourse);
      return Ok(new { message = "Course deleted successfully" });
   }
}