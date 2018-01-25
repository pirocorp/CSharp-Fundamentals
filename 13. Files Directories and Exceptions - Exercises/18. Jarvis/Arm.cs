using System;

namespace _18.Jarvis
{
    public class Arm
    {
        public Arm(long energyConsumption, long armReachDistance, long countOfFingers)
        {
            EnergyConsumption = energyConsumption;
            ArmReachDistance = armReachDistance;
            CountOfFingers = countOfFingers;
        }

        public long EnergyConsumption { get; set; }
        public long ArmReachDistance { get; set; }
        public long CountOfFingers  { get; set; }

        public static Arm Parse(string inputData)
        {
            var tokens = inputData.Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var energyConsumption = long.Parse(tokens[0]);
            var armReachDistance = long.Parse(tokens[1]);
            var countOfFingers = long.Parse(tokens[2]);

            return new Arm(energyConsumption, armReachDistance, countOfFingers);
        }

        public override string ToString()
        {
            var result = "#Arm:" + Environment.NewLine +
                         $"###Energy consumption: {this.EnergyConsumption}" + Environment.NewLine +
                         $"###Reach: {this.ArmReachDistance}" + Environment.NewLine +
                         $"###Fingers: {this.CountOfFingers}";

            return result;
        }
    }
}