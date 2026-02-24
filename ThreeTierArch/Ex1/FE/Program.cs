using System;
using BL;   // reference to BL project

namespace FE
{
    class Program
    {
        public static void Main(string[] args)
        {
            BusinessLogic bl = new BusinessLogic();

            string result = bl.GetFormattedName();

            Console.WriteLine(result);
        }
    }
}