using System;

namespace TouristInformation
{
    class TouristInformation
    {
        static void Main()
        {
            var typeImperialUnit = Console.ReadLine();
            double valueImperialUnit = double.Parse(Console.ReadLine());

            var mile = 1.6;
            var inch = 2.54;
            var feet = 30.0;
            var yard = 0.91;
            var galon = 3.8;

            string convertedUnit = "";
            double valueConvertedUnit = 0.0;

            switch (typeImperialUnit)
            {
                case "miles":
                    convertedUnit = "kilometers";
                    valueConvertedUnit = valueImperialUnit * mile;
                    break;
                case "inches":
                    convertedUnit = "centimeters";
                    valueConvertedUnit = valueImperialUnit * inch;
                    break;
                case "feet":
                    convertedUnit = "centimeters";
                    valueConvertedUnit = valueImperialUnit * feet;
                    break;
                case "yards":
                    convertedUnit = "meters";
                    valueConvertedUnit = valueImperialUnit * yard;
                    break;
                case "gallons":
                    convertedUnit = "liters";
                    valueConvertedUnit = valueImperialUnit * galon;
                    break;
                default: break;
            }

            Console.WriteLine($"{valueImperialUnit} {typeImperialUnit} = {valueConvertedUnit:f2} {convertedUnit}");
        }
    }
}
