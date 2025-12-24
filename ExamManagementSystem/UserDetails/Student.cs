namespace UserDetails
{
    public class StudentDetails : CommonUser
    {
        public int CourseID;
        public int ExaminerID;

        public StudentDetails(int id, int roleid, string name, int courseid) : base(id, roleid, name)
        {
            this.CourseID = courseid;
            ExaminerID = 0;
        }
    }
}