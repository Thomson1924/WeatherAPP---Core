using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherAPP___Core.Data;
using WeatherAPP___Core.Models;
using WeatherAPP___Core.Services;

namespace RagoWeather.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;
        public RestService _rs { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _rs = new RestService();
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index Request");
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult WeatherData(string id)
        {
            string prova = "https://api.openweathermap.org/data/2.5/weather?q=+" + id + "&units=metric&appid=0770f1c5ab85fe7ddff0cf0e60b1efac";
            WeatherData results =  _rs.GetWeatherData(prova).Result;

            return View(results);
        }

        public void SaveWeather(Main main)
        {
            foreach (var item in (IEnumerable <Main>) main)
            {
                var weather = new List<Main>
                {
                    new Main { Temperature = item.Temperature, Humidity=item.Humidity, Id=item.Id, Percepita=item.Percepita, Pressure=item.Pressure,
                        TempMax=item.TempMax, TempMin=item.TempMin, User=item.User, UserId=item.UserId }
                };

                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    context.mains.AddRange(weather);
                    context.SaveChanges();
                }
            }
        }
    }
}
