using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAPP___Core.Models
{
    public class ForecastData
    {
       
            [JsonProperty("temp")]
            public double Temp { get; set; }
            [JsonProperty("feels like")]
            public double Feels_like { get; set; }
            [JsonProperty("temp min")]
            public double Temp_min { get; set; }
            [JsonProperty("temp max")]
            public double Temp_max { get; set; }
            [JsonProperty("pressure")]
            public int Pressure { get; set; }
            [JsonProperty("sea level")]
            public int Sea_level { get; set; }
            [JsonProperty("grand level")]
            public int Grnd_level { get; set; }
            [JsonProperty("humidity")]
            public int Humidity { get; set; }
            [JsonProperty("temp kf")]
            public double Temp_kf { get; set; }
            [JsonProperty("wind speed")]
             public double Speed { get; set; }


/*
        public class Weather
        {
            public int Id { get; set; }
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }

        public class Clouds
        {
            public int All { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
            public int Deg { get; set; }
            public double Gust { get; set; }
        }

        public class Sys
        {
            public string Pod { get; set; }
        }

        public class Rain
        {
            public double _3h { get; set; }
        }

        public class List
        {
            public int Dt { get; set; }
            public Main Main { get; set; }
            public List<Weather> Weather { get; set; }
            public Clouds Clouds { get; set; }
            public Wind Wind { get; set; }
            public int Visibility { get; set; }
            public double Pop { get; set; }
            public Sys Sys { get; set; }
            public string Dt_txt { get; set; }
            public Rain Rain { get; set; }
        }

        public class Coord
        {
            public double Lat { get; set; }
            public double Lon { get; set; }
        }

        public class City
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Coord Coord { get; set; }
            public string Country { get; set; }
            public int Population { get; set; }
            public int Timezone { get; set; }
            public int Sunrise { get; set; }
            public int Sunset { get; set; }
        }

        public class Root
        {
            public string Cod { get; set; }
            public int Message { get; set; }
            public int Cnt { get; set; }
            public List<List> List { get; set; }
            public City City { get; set; }
        }*/
    }
}
