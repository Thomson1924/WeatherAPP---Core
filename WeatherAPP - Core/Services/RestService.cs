using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherAPP___Core.Models;
using WeatherAPP___Core.Models.ForecastData;
using WeatherAPP___Core.Models.HistoricalData;

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
        public async Task<Root> GetForecastData(string query)
        {
            Root forecastData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    forecastData = JsonConvert.DeserializeObject<Root>(content);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return forecastData;
        }

        public async Task<Rooth> GetHistoricalData(string query)
        {
            Rooth historicalData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    historicalData = JsonConvert.DeserializeObject<Rooth>(content);
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

