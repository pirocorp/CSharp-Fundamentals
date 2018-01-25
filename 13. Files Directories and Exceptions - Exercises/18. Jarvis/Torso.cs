using System;
using System.Linq;

namespace _18.Jarvis
{
    public class Torso
    {
        public Torso(long energyConsumption, double processorSizeInCm, string housingMaterial)
        {
            EnergyConsumption = energyConsumption;
            ProcessorSizeInCm = processorSizeInCm;
            HousingMaterial = housingMaterial;
        }

        public long EnergyConsumption { get; set; }
        public double ProcessorSizeInCm { get; set; }
        public string HousingMaterial { get; set; }

        public static Torso Parse(string inputData)
        {
            var tokens = inputData.Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var energyConsumption = long.Parse(tokens[0]);
            var processorSizeInCm = double.Parse(tokens[1]);
            var housingMaterial = String.Join(" ", tokens.Skip(2));

            return new Torso(energyConsumption, processorSizeInCm, housingMaterial);
        }

        public override string ToString()
        {
            var result = "#Torso:" + Environment.NewLine +
                         $"###Energy consumption: {this.EnergyConsumption}" + Environment.NewLine +
                         $"###Processor size: {this.ProcessorSizeInCm:F1}" + Environment.NewLine +
                         $"###Corpus material: {this.HousingMaterial}";

            return result;
        }
    }
}