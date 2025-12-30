namespace StaticUsers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int i = GeneralUser.GetRoll();
            int j = GeneralUser.GetRoll();
            int k = GeneralUser.GetRoll();
            Console.WriteLine($"{i} and {j} and {k}");
        }
    }
}