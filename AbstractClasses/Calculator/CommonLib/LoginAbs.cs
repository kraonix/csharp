namespace CommonLib
{
    public abstract class LoginAbs
    {
        public abstract void Login(string username, string password);
        public abstract void Logout();

        public bool ProginProcess()
        {
            return true;
        }
    }
}
