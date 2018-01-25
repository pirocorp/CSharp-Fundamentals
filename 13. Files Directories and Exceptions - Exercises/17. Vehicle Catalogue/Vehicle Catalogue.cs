using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.Vehicle_Catalogue
{
    class Program
    {
        static void Main()
        {
            var vehicles = new List<Vehicle>();
            var inputData = Console.ReadLine();

            while (inputData != "End")
            {
                vehicles.Add(Vehicle.Parse(inputData));
                inputData = Console.ReadLine();
            }

            inputData = Console.ReadLine();

            while (inputData != "Close the Catalogue")
            {
                var result = vehicles.Find(x => x.Model == inputData);
                Console.WriteLine($"Type: {(result.Type.ToLower() == "car"?"Car":"Truck")}");
                Console.WriteLine($"Model: {result.Model}");
                Console.WriteLine($"Color: {result.Color}");
                Console.WriteLine($"Horsepower: {result.Horsepower}");
                inputData = Console.ReadLine();
            }

            var carTypeVehicles = vehicles.Where(x => x.Type.ToLower() == "car").ToList();
            var carAverageHorsepower = carTypeVehicles.Sum(x => x.Horsepower) / (double)carTypeVehicles.Count;
            var truckTypeVehicles = vehicles.Where(x => x.Type.ToLower() == "truck").ToList();
            var truckAverageHorsepower = truckTypeVehicles.Sum(x => x.Horsepower) / (double)truckTypeVehicles.Count;
            Console.WriteLine($"Cars have average horsepower of: {(double.IsNaN(carAverageHorsepower) ? "0.00" : $"{carAverageHorsepower:F2}")}.");
            Console.WriteLine($"Trucks have average horsepower of: {(double.IsNaN(truckAverageHorsepower)?"0.00":$"{truckAverageHorsepower:F2}")}.");
        }
    }
}
