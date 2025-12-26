using System;

namespace RobotHazardAnalyzer
{
    public class Program
    {
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            if (armPrecision < 0.0 || armPrecision > 1.0)
                throw new ArgumentOutOfRangeException(nameof(armPrecision), "Arm precision must be between 0.0 and 1.0");

            if (workerDensity < 1 || workerDensity > 20)
                throw new ArgumentOutOfRangeException(nameof(workerDensity), "Worker density must be between 1 and 20");

            if (string.IsNullOrWhiteSpace(machineryState))
                throw new ArgumentNullException(nameof(machineryState), "Machinery state cannot be empty");

            machineryState = machineryState.Trim().ToLower();

            double machineRiskFactor;

            switch (machineryState)
            {
                case "worn":
                    machineRiskFactor = 1.2;
                    break;
                case "critical":
                    machineRiskFactor = 2.0;
                    break;
                case "faulty":
                    machineRiskFactor = 3.0;
                    break;
                default:
                    throw new ArgumentException("Machinery state must be Worn, Critical or Faulty");
            }

            double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
            return hazardRisk;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            double risk = p.CalculateHazardRisk(0.8, 15, "Worn");
            Console.WriteLine("Calculated Hazard Risk: " + risk);
        }
    }
}
