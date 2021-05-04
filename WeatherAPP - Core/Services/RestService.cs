using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherAPP___Core.Models;


namespace WeatherAPP___Core.Services
{
    public class RestService
    {
        HttpClient _client;


        public RestService()
        {
            _client = new HttpClient();

        }

        public async Task<WeatherData> GetWeatherData(string query)
        {
            WeatherData weatherData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return weatherData;
        }
        public async Task<WeatherData> GetHistoricalData(string query)
        {
            WeatherData historicalData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    historicalData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return historicalData;
        }
    }
}

