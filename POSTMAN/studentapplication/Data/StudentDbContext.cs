using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using studentapplication.Models;
using studentapplication.Models;

namespace studentapplication.Data
{
	public class StudentDbContext : DbContext
	{
		public StudentDbContext(DbContextOptions<StudentDbContext> options)
			: base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
	}
}