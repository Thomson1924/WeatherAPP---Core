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
using WeatherAPP___Core.Models.HistoricalData;

namespace WeatherAPP___Core.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;
        public RestService _rs { get; set; }
        public readonly ISave _save;
        private readonly UserManager<IdentityUser> _userManager;
        public ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ISave save, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _save = save;
            _rs = new RestService();
            _userManager = userManager;
            _context = context;

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


        public IActionResult Result(LocationModel location)
        {
            return RedirectToAction("WeatherData", "Home", new { lat=Math.Round(location.Latitude,3) , lon=Math.Round(location.Longitude,3)});
        }

        public IActionResult WeatherData(double lat, double lon, LocationModel location)
        { 

            string prova = "https://api.openweathermap.org/data/2.5/weather?lat="+ lat + "&lon=" + lon + "&units=metric&appid=0770f1c5ab85fe7ddff0cf0e60b1efac";
            WeatherData results = _rs.GetWeatherData(prova).Result;

            
            /*var currentUser = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
            results.Main.User = currentUser;
            results.Main.CityName = results.Title;
            _save.SaveAsync(results.Main);*/
            
            return View(results);
        }
        public IActionResult HistoricalData(string id)
        {
            string prova = "https://history.openweathermap.org/data/2.5/aggregated/year?q=" + id + "&units=metric&appid=0770f1c5ab85fe7ddff0cf0e60b1efac";
            Rooth results = _rs.GetHistoricalData(prova).Result;

            return View(results);
        }
        public IActionResult ForecastData(string id)
        {
            string prova = "https://api.openweathermap.org/data/2.5/forecast?q=" + id + "&mode=json&lang=pl&units=metric&appid=0770f1c5ab85fe7ddff0cf0e60b1efac";
            Root results = _rs.GetForecastData(prova).Result;


            return View(results);
        }
        [Authorize]
        public IActionResult MyWeather()
        {
            /*WeatherAPP___Core.Models.Main viewData = new WeatherAPP___Core.Models.Main();
            foreach (var col in _context.mains.ToList())
            {
                WeatherAPP___Core.Models.Main element = new WeatherAPP___Core.Models.Main();
                element.Temperature = col.Temperature;
                element.Pressure = col.Pressure;
                element.Humidity = col.Humidity;
                element.TempMin = col.TempMin;
                element.TempMax = col.TempMax;
                element.Percepita = col.Percepita;

                viewData.(element);
            }*/
            var currentUser = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;

            var viewData = _context.mains.Where(q => q.User == currentUser).Select(p => p).ToList();

            return View(viewData);
        }
    }
}
