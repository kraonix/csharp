using System.Net.Http;
using System.Net.Http.Json;
using StudentPortal_MVC.Models;

namespace StudentPortal_MVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("https://localhost:59573/api/");
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _http.GetFromJsonAsync<List<Student>>("Students");
        }

        public async Task<List<Enrollment>> GetEnrollments()
        {
            return await _http.GetFromJsonAsync<List<Enrollment>>("Enrollments");
        }

        public async Task<List<Course>> GetCourses()
        {
            return await _http.GetFromJsonAsync<List<Course>>("Courses");
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _http.GetFromJsonAsync<Course>($"Courses/{id}");
        }

        public async Task CreateCourse(Course course)
        {
            await _http.PostAsJsonAsync("Courses", course);
        }

        public async Task UpdateCourse(int id, Course course)
        {
            await _http.PutAsJsonAsync($"Courses/{id}", course);
        }

        public async Task DeleteCourse(int id)
        {
            await _http.DeleteAsync($"Courses/{id}");
        }
    }
}