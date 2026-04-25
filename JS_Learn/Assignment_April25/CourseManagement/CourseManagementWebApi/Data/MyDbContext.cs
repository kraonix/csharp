using CourseManagementWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementWebApi.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }
    public DbSet<Course> Courses { get; set; }
}