using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // 🔥 CORE TABLES
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }

        // 🔥 PROFILE TABLES
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<FacultyProfile> FacultyProfiles { get; set; }

        // 🔥 ACADEMIC TABLES
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        // 🔥 RELATION CONFIG
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            builder.Entity<Course>()
                .HasOne(c => c.Faculty)
                .WithMany()
                .HasForeignKey(c => c.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentProfile>()
                .HasOne(sp => sp.User)
                .WithOne()
                .HasForeignKey<StudentProfile>(sp => sp.UserId);

            builder.Entity<FacultyProfile>()
                .HasOne(fp => fp.User)
                .WithOne()
                .HasForeignKey<FacultyProfile>(fp => fp.UserId);

            builder.Entity<Submission>()
                .HasOne(s => s.Assignment)
                .WithMany(a => a.Submissions)
                .HasForeignKey(s => s.AssignmentId);

            builder.Entity<Submission>()
                .HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
                .HasOne(a => a.Course)
                .WithMany()
                .HasForeignKey(a => a.CourseId);
        }
    }
}