using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherAPP___Core.Data;
using WeatherAPP___Core.Interfaces;
using WeatherAPP___Core.Models;
using WeatherAPP___Core.Models.ForecastData;
using WeatherAPP___Core.Services;

namespace RagoWeather.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;
        public RestService _rs { get; set; }
        public readonly ISave _save;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger, ISave save, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _save = save;
            _rs = new RestService();
            _userManager = userManager;

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
        
            string prova = "https://api.openweathermap.org/data/2.5/weather?q=" + id + "&lang=pl&units=metric&appid=0770f1c5ab85fe7ddff0cf0e60b1efac";
            WeatherData results = _rs.GetWeatherData(prova).Result;

            results.Main.User = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;   
            _save.SaveAsync(results.Main);

            return View(results);
        }
        public IActionResult HistoricalData(string id)
        {
            string prova = "https://api.openweathermap.org/data/2.5/weather?q=" + id + "&lang=pl&units=metric&appid=0770f1c5ab85fe7ddff0cf0e60b1efac";
            WeatherData results = _rs.GetWeatherData(prova).Result;

            return View(results);
        }
        public IActionResult ForecastData(string id)
        {
            string prova = "https://api.openweathermap.org/data/2.5/forecast?q=" + id + "&mode=json&lang=pl&units=metric&appid=0770f1c5ab85fe7ddff0cf0e60b1efac";
            Root results = _rs.GetForecastData(prova).Result;


            return View(results);
        }
    }
}
