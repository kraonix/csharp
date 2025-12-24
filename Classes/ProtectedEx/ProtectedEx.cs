namespace ProtectedEx.Pro
{
    public class Protected
    {
        protected int protectedValue = 42;

        protected void ShowProtectedValue()
        {
            Console.WriteLine($"Protected Value: {protectedValue}");
        }
    }

    class Program : Protected
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// This is the main entry point of the program.
            /// It demonstrates the use of protected access modifiers
            /// through inheritance and method overriding.
            /// </summary>

            Program program = new Program();
            program.ShowProtectedValue();
        }
    }
}
