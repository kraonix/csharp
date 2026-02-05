using System;
using System.Collections.Generic;
using System.Linq;

public class LearningManager
{
    private readonly List<Course> _courses = new();
    private readonly List<Enrollment> _enrollments = new();
    private readonly List<StudentProgress> _progressList = new();

    private int _enrollmentCounter = 1;

    // Add Course
    public void AddCourse(string code, string name, string instructor,
                          int weeks, double price, List<string> modules)
    {
        _courses.Add(new Course
        {
            CourseCode = code,
            CourseName = name,
            Instructor = instructor,
            DurationWeeks = weeks,
            Price = price,
            Modules = modules
        });
    }

    // Enroll Student
    public bool EnrollStudent(string studentId, string courseCode)
    {
        if (!_courses.Any(c => c.CourseCode == courseCode))
            return false;

        if (_enrollments.Any(e => e.StudentId == studentId &&
                                  e.CourseCode == courseCode))
            return false;

        _enrollments.Add(new Enrollment
        {
            EnrollmentId = _enrollmentCounter++,
            StudentId = studentId,
            CourseCode = courseCode,
            EnrollmentDate = DateTime.Now,
            ProgressPercentage = 0
        });

        _progressList.Add(new StudentProgress
        {
            StudentId = studentId,
            CourseCode = courseCode,
            LastAccessed = DateTime.Now
        });

        return true;
    }

    // Update Progress
    public bool UpdateProgress(string studentId, string courseCode,
                               string module, double score)
    {
        var progress = _progressList.FirstOrDefault(p =>
            p.StudentId == studentId && p.CourseCode == courseCode);

        var course = _courses.FirstOrDefault(c => c.CourseCode == courseCode);

        if (progress == null || course == null || !course.Modules.Contains(module))
            return false;

        progress.ModuleScores[module] = score;
        progress.LastAccessed = DateTime.Now;

        var enrollment = _enrollments.First(e =>
            e.StudentId == studentId && e.CourseCode == courseCode);

        enrollment.ProgressPercentage =
            (progress.ModuleScores.Count * 100.0) / course.Modules.Count;

        return true;
    }

    // Group Courses by Instructor
    public Dictionary<string, List<Course>> GroupCoursesByInstructor()
    {
        return _courses
            .GroupBy(c => c.Instructor)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Top Performing Students
    public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
    {
        return _enrollments
            .Where(e => e.CourseCode == courseCode)
            .OrderByDescending(e => e.ProgressPercentage)
            .Take(count)
            .ToList();
    }

    // Helpers for menu
    public List<Course> GetAllCourses() => _courses;
    public List<Enrollment> GetAllEnrollments() => _enrollments;
}
