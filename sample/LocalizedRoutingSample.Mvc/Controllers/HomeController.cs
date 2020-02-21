using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LocalizedRoutingSample.Mvc.Models;
using Kentico.AspNetCore.LocalizedRouting.Attributes;

namespace LocalizedRoutingSample.Mvc.Controllers
{
    //[LocalizedRoute("en-US", "home")]
    //[LocalizedRoute("cs-CZ", "domu")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[LocalizedRoute("en-US", "index")]
        //[LocalizedRoute("cs-CZ", "uvod")]
        public IActionResult Index()
        {
            return View();
        }

        //[LocalizedRoute("en-US", "privacy")]
        //[LocalizedRoute("cs-CZ", "soukromi")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
