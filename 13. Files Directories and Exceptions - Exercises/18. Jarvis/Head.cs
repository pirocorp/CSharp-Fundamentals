using System;
using System.Linq;

namespace _18.Jarvis
{
    public class Head
    {
        public Head(long energyConsumption, long iq, string skinMaterial)
        {
            EnergyConsumption = energyConsumption;
            Iq = iq;
            SkinMaterial = skinMaterial;
        }

        public long EnergyConsumption { get; set; }
        public long Iq { get; set; }
        public string SkinMaterial { get; set; }

        public static Head Parse(string inputData)
        {
            var tokens = inputData.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var energyConsumption = long.Parse(tokens[0]);
            var iq = long.Parse(tokens[1]);
            var skinMaterial = String.Join(" ", tokens.Skip(2));

            return new Head(energyConsumption, iq, skinMaterial);
        }

        public override string ToString()
        {
            var result = "#Head:" + Environment.NewLine +
                            $"###Energy consumption: {this.EnergyConsumption}" + Environment.NewLine +
                            $"###IQ: {this.Iq}" + Environment.NewLine +
                            $"###Skin material: {this.SkinMaterial}";

            return result;
        }
    }
}