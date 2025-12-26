using System;
namespace BasicOfBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (false) //uncomment to test Add method
            {
                int n = 5;
                Someclass someclass = new Someclass();
                string result = someclass.SomeMethod(ref n);
                Console.WriteLine(result);
                int input1 = 3;
                int input2 = 4;

                Console.WriteLine($"input1 before fun called {input1}");
                Console.WriteLine($"input2 before fun called {input2}");

                int sum = someclass.SomeMethod(ref input1, ref input2);
                Console.WriteLine($"Sum with two parameter {sum}");

                //ref is used to pass the parameter by reference
                //it means any changes made to the parameter inside the method will be reflected outside the method
                //the original value of the parameter will be changed
                //its pointing to the original memory location of the variable

                Console.WriteLine($"input1 after fun called {input1}");
                Console.WriteLine($"input2 after fun called {input2}");
                int x = int.MaxValue; //round robin (doesnt throw overflow exception) using in games
                int y = 10;
                Someclass someclass = new Someclass();
                int result = someclass.Add(x, y);
                Console.WriteLine($"Addition of {x} and {y} is {result}");
            }
            //out parameter
            Someclass someclass = new Someclass();
            int n = 10;
            int sqareValue, halfValue, addBy3;
            int original = someclass.MultiMath(n, out sqareValue, out halfValue,out addBy3);
            Console.WriteLine($"Original Value: {original},Square: {sqareValue}, halfValue: {halfValue}, AddBy3: {addBy3}");
        }
    }    
    public class Someclass
    {
        public string SomeMethod(ref int n)
        {
            return $"Method with some parameter called { n }";
        }
        //method with two parameter
        //using ref keyword
        public int SomeMethod(ref int a,ref int b)
        {
            int n = a + b;
            a = 100;
            b = 200;
            return n;
        }
        public int Add(int x, int y)
        {
            //checked is used to check & throw overflow exception
            checked
            {
                int c = x + y;
                return c;
            }
        }
        //method with out parameter
        public int MultiMath(int n, out int sqrValue, out int halfValue,out int addBy3)
        {
            sqrValue = n * n;
            halfValue = n / 2;
            addBy3 = n + 3;
            return n;
        }

    }
}
