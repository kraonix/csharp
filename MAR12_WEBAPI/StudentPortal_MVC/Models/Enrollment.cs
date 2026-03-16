namespace StudentPortal_MVC.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public string? PaymentStatus { get; set; }

        public decimal PaidAmount { get; set; }
    }
}