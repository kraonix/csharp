using System;
namespace Oops
{
    // Interfaces defining specific behaviors
    public interface IBird
    {
        void Fly();
    }
    public interface ISwimmer
    {
        void Swim();
    }
    public interface IWalker
    {
        void Walk();
    }
    public interface ISinger
    {
        void Sing();
    }

    // Composite interface for Duck
    public interface IDuck : IBird, ISwimmer, IWalker
    {
        void Quack();
    }

    // Composite interface for Bat
    public interface IBat : IBird, IWalker
    {
        void Echolocate();
    }

    public class Sparrow : IBird, IWalker, ISinger
    {
        public void Fly()
        {
            // Implementation of flying behavior
            Console.WriteLine("Sparrow is flying.");
        }
        public void Walk()
        {
            // Implementation of walking behavior
            Console.WriteLine("Sparrow is walking.");
        }
        public void Sing()
        {
            // Implementation of singing behavior
            Console.WriteLine("Sparrow is singing.");
        }
    }
    public class Duck : IDuck
    {
        public void Fly()
        {
            // Implementation of flying behavior
            Console.WriteLine("Duck is flying.");
        }
        public void Walk()
        {
            // Implementation of walking behavior
            Console.WriteLine("Duck is walking.");
        }
        public void Swim()
        {
            // Implementation of swimming behavior
            Console.WriteLine("Duck is swimming.");
        }
        public void Quack()
        {
            // Implementation of quacking behavior
            Console.WriteLine("Duck is quacking.");
        }
    }
    public class Bat : IBat
    {
        public void Fly()
        {
            // Implementation of flying behavior
            Console.WriteLine("Bat is flying.");
        }
        public void Walk()
        {
            // Implementation of walking behavior
            Console.WriteLine("Bat is walking.");
        }
        public void Echolocate()
        {
            // Implementation of echolocation behavior
            Console.WriteLine("Bat is echolocating.");
        }
    }

}