namespace StaticUsers
{
    public static class GeneralUser
    {
        public static int Roll;

        static GeneralUser()
        {
            Roll = 1;
        }

        public static int GetRoll()
        {
            return Roll++;
        }
    }
}