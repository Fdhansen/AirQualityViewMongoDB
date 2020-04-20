using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AirQualityMVC.Models;
using MongoDB.Driver;

namespace AirQualityMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AirQualityContext ctx = new AirQualityContext();
        public IActionResult Index()
        {
            var airQuality = ctx.AirQualityData.AsQueryable();
            return View(airQuality);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
    }
}
