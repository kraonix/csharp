using System;
using System.Collections.Generic;
using System.Linq;

public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

// 1. Generic enrollment system
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();

    public bool EnrollStudent(TStudent student, TCourse course)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        if (course == null)
            throw new ArgumentNullException(nameof(course));

        if (!_enrollments.ContainsKey(course))
            _enrollments[course] = new List<TStudent>();

        var students = _enrollments[course];

        if (students.Count >= course.MaxCapacity)
            return false;

        if (students.Any(s => s.StudentId == student.StudentId))
            return false;

        if (course is LabCourse lab && student.Semester < lab.RequiredSemester)
            return false;

        students.Add(student);
        return true;
    }

    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (course == null)
            throw new ArgumentNullException(nameof(course));

        return _enrollments.ContainsKey(course)
            ? _enrollments[course].AsReadOnly()
            : Array.Empty<TStudent>();
    }

    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        return _enrollments
            .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
            .Select(e => e.Key);
    }

    public int CalculateStudentWorkload(TStudent student)
    {
        return GetStudentCourses(student).Sum(c => c.Credits);
    }
}

// 2. Specialized implementations
public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; }
}

// 3. Generic gradebook
public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private readonly EnrollmentSystem<TStudent, TCourse> _enrollment;
    private Dictionary<(TStudent, TCourse), double> _grades = new();

    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
    {
        _enrollment = enrollment ?? throw new ArgumentNullException(nameof(enrollment));
    }

    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentException("Grade must be between 0 and 100");

        var enrolled = _enrollment.GetEnrolledStudents(course).Any(s => s.StudentId == student.StudentId);

        if (!enrolled)
            throw new InvalidOperationException("Student not enrolled in course");

        _grades[(student, course)] = grade;
    }

    public double? CalculateGPA(TStudent student)
    {
        var records = _grades
            .Where(g => EqualityComparer<TStudent>.Default.Equals(g.Key.Item1, student))
            .ToList();

        if (!records.Any())
            return null;

        var totalCredits = records.Sum(r => r.Key.Item2.Credits);
        var weightedScore = records.Sum(r => r.Value * r.Key.Item2.Credits);

        return weightedScore / totalCredits;
    }

    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var top = _grades
            .Where(g => EqualityComparer<TCourse>.Default.Equals(g.Key.Item2, course))
            .OrderByDescending(g => g.Value)
            .FirstOrDefault();

        if (top.Equals(default(KeyValuePair<(TStudent, TCourse), double>)))
            return null;

        return (top.Key.Item1, top.Value);
    }
}

public class Program
{
    public static void Main()
    {
        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();

        var s1 = new EngineeringStudent { StudentId = 1, Name = "A", Semester = 3, Specialization = "CSE" };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "B", Semester = 1, Specialization = "ECE" };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "C", Semester = 4, Specialization = "ME" };

        var c1 = new LabCourse { CourseCode = "LAB101", Title = "Physics Lab", MaxCapacity = 2, Credits = 3, RequiredSemester = 2 };
        var c2 = new LabCourse { CourseCode = "LAB201", Title = "Advanced Lab", MaxCapacity = 1, Credits = 4, RequiredSemester = 4 };

        Console.WriteLine("\n===== ENROLLMENT PHASE =====\n");

        TryEnroll(enrollment, s1, c1);
        TryEnroll(enrollment, s2, c1);
        TryEnroll(enrollment, s3, c1);
        TryEnroll(enrollment, s2, c2);
        TryEnroll(enrollment, s3, c2);

        Console.WriteLine("\n===== COURSE ROSTER =====\n");

        PrintCourseRoster(enrollment, c1);
        PrintCourseRoster(enrollment, c2);

        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

        Console.WriteLine("\n===== GRADING PHASE =====\n");

        gradeBook.AddGrade(s1, c1, 85);
        gradeBook.AddGrade(s3, c1, 92);
        gradeBook.AddGrade(s3, c2, 88);

        Console.WriteLine("===== GPA CALCULATION =====\n");

        Console.WriteLine($"{s3.Name}'s GPA: {gradeBook.CalculateGPA(s3):F2}");

        Console.WriteLine("\n===== TOP STUDENT PER COURSE =====\n");

        PrintTopStudent(gradeBook, c1);
        PrintTopStudent(gradeBook, c2);
    }

    static void TryEnroll(EnrollmentSystem<EngineeringStudent, LabCourse> enrollment, EngineeringStudent student, LabCourse course)
    {
        var result = enrollment.EnrollStudent(student, course);

        Console.WriteLine($"Enroll {student.Name} -> {course.Title} : {(result ? "Success" : "Failed")}");
    }

    static void PrintCourseRoster(EnrollmentSystem<EngineeringStudent, LabCourse> enrollment, LabCourse course)
    {
        var students = enrollment.GetEnrolledStudents(course);

        Console.WriteLine($"Course: {course.Title} ({course.CourseCode})");
        Console.WriteLine($"Capacity: {students.Count}/{course.MaxCapacity}");

        foreach (var s in students)
            Console.WriteLine($" - {s.Name} (Semester {s.Semester}, {s.Specialization})");

        Console.WriteLine();
    }

    static void PrintTopStudent(GradeBook<EngineeringStudent, LabCourse> gradeBook, LabCourse course)
    {
        var top = gradeBook.GetTopStudent(course);

        if (top == null)
        {
            Console.WriteLine($"{course.Title}: No grades available.");
            return;
        }

        Console.WriteLine($"{course.Title}: Top Student = {top.Value.student.Name}, Grade = {top.Value.grade}");
    }

}