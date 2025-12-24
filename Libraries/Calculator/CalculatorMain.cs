using MathsLib;
using ScienceLib;

class CalculatorMain
{
    /// <summary>
    /// Main entry point for the Calculator application.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // Example usage of MathsLib
        Algebra arg = new Algebra();
        Console.Write("Addition : " + arg.Add(5, 3) + "\n");

        // Example usage of ScienceLib
        AeroScience aero = new AeroScience();
        Console.Write("Lift : " + aero.CalculateLift(10.0, 1.2, 1.225, 50.0));
    }
}