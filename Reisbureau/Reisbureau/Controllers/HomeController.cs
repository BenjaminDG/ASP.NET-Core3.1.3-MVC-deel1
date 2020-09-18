using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reisbureau.Models;
using Microsoft.AspNetCore.Http;
using Reisbureau.Services;

namespace Reisbureau.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BrochureService _brochureService; 

        public HomeController( BrochureService brochureService)
        {
            _brochureService = brochureService;
            

        }

        public IActionResult Index()
        {
            
            
            string laatsteBezoek = DateTime.Now.ToString();
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(365);
            Response.Cookies.Append("lastvisit", laatsteBezoek, option);
            
            var brochures = _brochureService.FindAll();

            if (Request.Cookies["lastvisit"] == null) { return Redirect("~/Klant/Toevoegen"); }
            else 
                return View();
        }

        [HttpGet]
        public IActionResult BrochureToevoegen()
        {
            var brochure = new Brochure();
            return View(brochure);
        }

        [HttpPost]
        public IActionResult BrochureToevoegen(Brochure b)
        {
            if (this.ModelState.IsValid)
            {
                _brochureService.Add(b);
                return Redirect("~/");

            }
            else return View(b);
        }

        public IActionResult Winkelmandje() { return View(_brochureService.FindAll()); }

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
