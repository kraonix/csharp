using Family;

class Program
{
    static void Main(string[] args)
    {
        Father father = new Father();
        Son son = new Son();

        System.Console.WriteLine("Father's Interest: " + father.IntrestOn());
        System.Console.WriteLine("Son's Interest: " + son.IntrestOn());
    }
}