namespace _12.Weather
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Weather
    {
        static void Main()
        {
            var pattern = @"(?<cityCode>[A-Z]{2})(?<averageTemperature>\d{1,2}\.\d{1,2})(?<typeOfWeather>[A-Za-z]+)\|";
            var inputLine = Console.ReadLine();
            var cities = new List<City>();

            while (inputLine != "end")
            {
                var currentCity = Regex.Match(inputLine, pattern);

                if (currentCity.Length > 0)
                {
                    var cityCode = currentCity.Groups["cityCode"].Value;
                    var averageTemperature = double.Parse(currentCity.Groups["averageTemperature"].Value);
                    var typeOfWeather = currentCity.Groups["typeOfWeather"].Value;

                    if (!cities.Any(x => x.CityCode == cityCode))
                    {
                        var city = new City(cityCode, averageTemperature, typeOfWeather);
                        cities.Add(city);
                    }

                    var cityInList = cities.First(x => x.CityCode == cityCode);
                    cityInList.Temperature = averageTemperature;
                    cityInList.TypeOfWeather = typeOfWeather;
                }

                inputLine = Console.ReadLine();
            }

            cities = cities.OrderBy(x => x.Temperature).ToList();

            for (var i = 0; i < cities.Count; i++)
            {
                var currentCity = cities[i];
                var nameOfTheCity = currentCity.CityCode;
                var averageTemperature = currentCity.Temperature;
                var typeOfWeather = currentCity.TypeOfWeather;

                Console.WriteLine($"{nameOfTheCity} => {averageTemperature:F2} => {typeOfWeather}");
            }
        }
    }
}