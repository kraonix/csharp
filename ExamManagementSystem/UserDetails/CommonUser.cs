using Roles;

namespace UserDetails
{
    /// <summary>
    /// Main Parent Class Containing basic details that are common for all Users!
    /// </summary>
    public class CommonUser : RoleAssign
    {
        public int ID;
        public int RoleID;
        public string Name;

        public CommonUser(int id, int roleid, string name)
            : base(roleid)
        {
            ID = id;
            RoleID = roleid;
            Name = name;
        }
    }
}