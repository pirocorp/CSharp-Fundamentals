using System;

namespace _18.Jarvis
{
    public class Leg
    {
        public Leg(long energyConsumption, long strength, long speed)
        {
            EnergyConsumption = energyConsumption;
            Strength = strength;
            Speed = speed;
        }

        public long EnergyConsumption { get; set; }
        public long Strength { get; set; }
        public long Speed { get; set; }

        public static Leg Parse(string inputData)
        {
            var tokens = inputData.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var energyConsumption = long.Parse(tokens[0]);
            var strength = long.Parse(tokens[1]);
            var speed = long.Parse(tokens[2]);

            return new Leg(energyConsumption, strength, speed);
        }

        public override string ToString()
        {
            var result = "#Leg:" + Environment.NewLine +
                         $"###Energy consumption: {this.EnergyConsumption}" + Environment.NewLine +
                         $"###Strength: {this.Strength}" + Environment.NewLine +
                         $"###Speed: {this.Speed}";

            return result;
        }
    }
}