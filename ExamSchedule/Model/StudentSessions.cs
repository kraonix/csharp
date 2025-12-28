namespace ExamSchedule.Model
{
    /// <summary>
    /// Represents a session associated with a student, including identifying and descriptive information.
    /// </summary>
    public class StudentSessions
    {
        public string? Id { get; set; }             // Unique identifier for the session
        public string? Name { get; set; }           // Name of the session
        public string? Description { get; set; }    // Description of the session

        // Constructor to initialize a new instance of the StudentSession class
        public StudentSessions()
        {

        }
    }
}