namespace UserDetails
{
    public class HODDetails : CommonUser
    {
        public int DepartmentID;

        public HODDetails(int id, int roleid, string name, int departmentid) : base(id, roleid, name)
        {
            this.DepartmentID = departmentid;
        }

    }
}