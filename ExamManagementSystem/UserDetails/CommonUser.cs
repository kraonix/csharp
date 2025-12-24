namespace UserDetails
{
    /// <summary>
    /// Main Parent Class Containing basic details that are common for all Users!
    /// </summary>
    public class CommonUser
    {
        public int ID;
        public int RoleID;
        public string Name;

        public CommonUser(int id, int roleid, string name)
        {
            this.ID = id;
            this.RoleID = roleid;
            this.Name = name;
        }
    }
}