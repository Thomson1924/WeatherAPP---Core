using Newtonsoft.Json;

namespace WeatherAPP___Core.Models
{
    public class HMain
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("feels_like")]
        public double Percepita { get; set; }
    }

    public class HWind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }
    }

    public class HClouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }

    public class HWeather
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public string Visibility { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class HRain
    {
        [JsonProperty("hour")]
        public double _1h { get; set; }
    }

    public class HList
    {
        [JsonProperty("dt")]
        public int dt { get; set; }
        [JsonProperty("main")]
        public Main main { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("rain")]
        public HRain rain { get; set; }
    }

    public class HRoot
    {
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("cod")]
        public long Cod { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
    }
        

    
}
