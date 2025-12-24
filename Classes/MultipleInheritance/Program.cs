class Program
{
    static void Main()
    {
        Final f = new Final();
        IVegEater veg = new Final();
        

        Console.WriteLine(f.EatVeg("Paneer"));
        Console.WriteLine(f.EatNonVeg("Chicken"));
        Console.WriteLine(veg.getTaste());

    }
}