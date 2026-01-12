namespace Multicast
{
    public delegate void MyDelegate(string message);
    
    class Program
    {
        static void MethodA(string msg) => Console.WriteLine("A: " + msg);
        static void MethodB(string msg) => Console.WriteLine("B: " + msg);
        static void MethodC(string msg) => Console.WriteLine("C: " + msg);
        public static void Main(string[] args)
        {
            MyDelegate d = MethodA;
            d += MethodB;
            d += MethodC;
            d("Hello");
        }
    }
}