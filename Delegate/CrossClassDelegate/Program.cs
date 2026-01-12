namespace Delegate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintingCompany printingCompany = new PrintingCompany();
            printingCompany.CustomerChoicePrintMessage = new PrintMessage(HappyNewYear);
            printingCompany.Print("Sachin");
        }

        private static string HappyNewYear(string message)
        {
            return "Happy New Year " + message;
        }

        private static string HappyDewali(string message)
        {
            return "Happy Dewali " + message;
        }
    }
}