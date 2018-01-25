using System;

namespace _17.Vehicle_Catalogue
{
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public static Vehicle Parse(string inputData)
        {
            var tokens = inputData.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var type = tokens[0];
            var model = tokens[1];
            var color = tokens[2];
            var horsepower = int.Parse(tokens[3]);

            return new Vehicle(type, model, color, horsepower);
        }
    }
}
