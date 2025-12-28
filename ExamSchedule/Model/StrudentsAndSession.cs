namespace ExamSchedule.Model
{
    /// <summary>
    /// Represents a data structure that associates a student with their session information.
    /// </summary>
    public class StudentsAndSession
    {
        // Constructor to initialize a new instance of the StudentsAndSession class
        public StudentsAndSession()
        {
            
        }

        public StudentSessions Sessions{ get; set; }        // Session information associated with the student
        public Student Students {  get; set; }              // Student information
    }
}