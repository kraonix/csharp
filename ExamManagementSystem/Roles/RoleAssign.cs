namespace Roles
{

    public class RoleAssign
    {
        protected int _roleId;

        public string Role { get; private set; }

        public RoleAssign(int roleId)
        {
            _roleId = roleId;
            AssignRole(roleId);
        }

        private void AssignRole(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    Role = "HOD";
                    break;
                case 2:
                    Role = "Examiner";
                    break;
                case 3:
                    Role = "Student";
                    break;
                default:
                    Role = "Unknown";
                    break;
            }
        }
    }
}