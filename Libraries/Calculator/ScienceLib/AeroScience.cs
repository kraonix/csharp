namespace ScienceLib
{

    /// <summary>
    /// Provides aerospace science calculations.
    /// </summary>
    public class AeroScience
    {
        public double CalculateLift(double area, double coefficient, double density, double velocity)
        {
            return 0.5 * area * coefficient * density * velocity * velocity;
        }

        public double CalculateDrag(double area, double coefficient, double density, double velocity)
        {
            return 0.5 * area * coefficient * density * velocity * velocity;
        }
    }
}