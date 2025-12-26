namespace UserDetails
{
    /// <summary>
    /// Represents a student user in the exam management system with course and examiner information
    /// </summary>
    public class StudentDetails : CommonUser
    {
        /// <summary>
        /// Gets or sets the ID of the course the student is enrolled in
        /// </summary>
        public int CourseID;

        /// <summary>
        /// Gets or sets the ID of the examiner assigned to the student
        /// </summary>
        public int ExaminerID;

        /// <summary>
        /// Initializes a new instance of the StudentDetails class
        /// </summary>

        public StudentDetails(int id, int roleid, string name, int courseid) : base(id, roleid, name)
        {
            // Set the course ID from the constructor parameter
            this.CourseID = courseid;
            
            // Initialize examiner ID to 0 (no examiner assigned initially)
            ExaminerID = 0;
        }
    }
}