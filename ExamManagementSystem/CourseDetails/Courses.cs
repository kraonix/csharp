
namespace CourseDetails
{
    public class Courses
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public Courses(int courseId)
        {
            CourseId = courseId;
            CourseName = GetCourseName(courseId);
        }

        private string GetCourseName(int courseId)
        {
            return courseId switch
            {
                1 => "MCA",
                2 => "Btech",
                3 => "MBA",
                _ => "Unknown"
            };
        }
    }
}
