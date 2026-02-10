using System;


public class Cab
{
    public virtual int CalculateFare(int km)
    {
        return km * 10;                         // Default pricing logic
    }
}

public class Mini : Cab
{
    public override int CalculateFare(int km)
    {
        return km * 12;
    }
}

public class Sedan : Cab
{
    public override int CalculateFare(int km)
    {
        return (km * 15) + 50;
    }
}

public class SUV : Cab
{
    public override int CalculateFare(int km)
    {
        return (km * 18) + 100;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Cab mini = new Mini();
        Cab sedan = new Sedan();
        Cab suv = new SUV();

        Console.WriteLine($"Mini Cab for 10 km: {mini.CalculateFare(10)}");
        Console.WriteLine($"Sedan Cab for 10 km: {sedan.CalculateFare(10)}");
        Console.WriteLine($"SUV Cab for 10 km: {suv.CalculateFare(10)}");
    }
}
