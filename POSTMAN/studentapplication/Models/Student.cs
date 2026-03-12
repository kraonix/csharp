using System.ComponentModel.DataAnnotations;

namespace studentapplication.Models
{
	public class Student
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string Department { get; set; }

		public int Age { get; set; }
	}
}