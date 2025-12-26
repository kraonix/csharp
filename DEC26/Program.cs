using System;
namespace Oops
{
   // Interfaces defining specific behaviors
   class Program
   {
       static void Main(string[] args)
       {
           // Creating and using a Sparrow instance
           Sparrow sparrow = new Sparrow();
           sparrow.Fly();
           sparrow.Walk();
           sparrow.Sing();

           IBird birdSparrow = sparrow;
           birdSparrow.Fly();
           birdSparrow = new Bat();
           birdSparrow.Fly();


           // Creating and using a Duck instance
           Duck duck = new Duck();
           duck.Fly();
           duck.Walk();
           duck.Swim();
           duck.Quack();

           // Creating and using a Bat instance
           Bat bat = new Bat();
           bat.Fly();
           bat.Walk();
           bat.Echolocate();
       }
   }
}

//=======================================================================================================

// class Program
// {
//     public static void Main()
//     {
        
//         int[][] data = new int[5][];
//         data[0] = new int[] { 1, 2, 3 };
//         data[1] = new int[] { 10, 20 };
//         data[2] = new int[] { 7, 8, 9, 10 };
//         data[3] = new int[] { 7, 8, 9, 10,56,10 };
//         data[4] = new int[] { 7, 8, 9, 10 ,56,10,45};
//         for (int i = 0; i < data.Length; i++)
//         {
//             Console.Write("Row " + i + ": ");
//             foreach (var v in data[i]) Console.Write(v + " ");
//             Console.WriteLine();
//         }
//     }
// }

//==============================================================================================================================

