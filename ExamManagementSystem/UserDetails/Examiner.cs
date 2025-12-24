namespace UserDetails
{
    public class ExaminerDetails : CommonUser
    {
        public int ExaminerID;

        public ExaminerDetails(int id, int roleid, string name, int examinerid) : base(id, roleid, name)
        {
            this.ExaminerID = examinerid;
        }
    }
}