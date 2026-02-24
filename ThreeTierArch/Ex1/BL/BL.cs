using EX1;   // reference to DAL project

namespace BL
{
    public class BusinessLogic
    {
        public string GetFormattedName()
        {
            DAL obj = new DAL();

            string name = obj.GetName();

            // Business logic example (formatting)
            return "Hello, " + name + "!";
        }
    }
}