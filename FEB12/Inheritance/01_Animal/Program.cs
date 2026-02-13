using System;
public class Animal
{
    public void Speak(){

        Console.WriteLine("Animal speaking");
    }
}
public class Dog
{
    public void Speak(){

        Console.WriteLine("Dog speaking");
    }
}
class Program
{
    static void Main()
    {
        Dog dog=new Animal();
        dog.Speak();
    }
}