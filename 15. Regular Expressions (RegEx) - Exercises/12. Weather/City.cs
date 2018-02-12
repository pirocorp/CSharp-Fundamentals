namespace _12.Weather
{
    public class City
    {
        public City(string cityCode, double temperature, string typeOfWeather)
        {
            CityCode = cityCode;
            Temperature = temperature;
            TypeOfWeather = typeOfWeather;
        }

        public string CityCode { get; set; }
        public double Temperature { get; set; }
        public string TypeOfWeather { get; set; }
    }
}