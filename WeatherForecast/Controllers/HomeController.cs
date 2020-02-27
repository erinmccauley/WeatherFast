using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        public List<ConsolidatedWeather> GetWeatherForecast()
        {
            string json = (new WebClient()).DownloadString("https://www.metaweather.com/api/location/44544/");
            RootObject result =  JsonConvert.DeserializeObject<RootObject>(json);
            List<ConsolidatedWeather> belfastForecast = new List<ConsolidatedWeather>();
            foreach (var forecast in result.consolidated_weather)
            {
                belfastForecast.Add(forecast);
            }
            return belfastForecast;
        }
        public ActionResult Index()
        {
            var model = GetWeatherForecast();
            return View(model);
        }
    }
}