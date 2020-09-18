using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using State.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace State.Controllers
{
    public class HomeController : Controller
    {
        /* private readonly ILogger<HomeController> _logger;

         public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;
         }*/

        private Counter _counter;
        public HomeController(Counter counter)
        {
            this._counter = counter;
        }

        public IActionResult Index()
        {

            var aantalBezoeken = HttpContext.Session.GetInt32("aantalBezoeken");
            if (aantalBezoeken == null)
            {
                HttpContext.Session.SetInt32("aantalBezoeken", 1);
            }
            else HttpContext.Session.SetInt32("aantalBezoeken", (int)aantalBezoeken + 1);
            ViewBag.aantalBezoeken = HttpContext.Session.GetInt32("aantalBezoeken");

            var laatsteBezoek = HttpContext.Session.GetString("lastvisit");
            if (string.IsNullOrEmpty(laatsteBezoek))
            {
                ViewBag.lastvisit = "geen";
            }
            else
            {
                ViewBag.lastvisit =
                JsonConvert.DeserializeObject<DateTime>(laatsteBezoek);
            }
            var geserializeerdeDatum = JsonConvert.SerializeObject(DateTime.Now);
            HttpContext.Session.SetString("lastvisit", geserializeerdeDatum);
            _counter.TotaalAantalBezoeken += 1;
            ViewBag.totaalAantalBezoeken = _counter.TotaalAantalBezoeken;
            return View();
            /*  string resultaat = "dit is jouw eerste bezoek";
              //is er een cookie met de naam "lastvisit"?
              if (Request.Cookies["lastvisit"] != null)
              {
                  // dan lezen we het rijdstip vh laatste bezoek uit de cookie
                  resultaat = "welkom terug. jouw laatste bezoek was op " + Request.Cookies["lastvisit"];
              }

              //we slaan het huidige tijdstip op als laatste bezoek
              string laatstebezoek = DateTime.Now.ToString();
              CookieOptions option = new CookieOptions();
              option.Expires = DateTime.Now.AddDays(365);
              Response.Cookies.Append("lastvisit", laatstebezoek, option);
              ViewBag.tijdstip = resultaat;
              return View();*/
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Wissen()
        {

            HttpContext.Session.Clear();
            _counter.TotaalAantalBezoeken = 0;
            //is er een cookie met de naam last visit?
            /*
            if(HttpContext.Session.GetInt32("aantalBezoeken") !=null)
            
                HttpContext.Session.Remove("aantalBezoeken");
                if (HttpContext.Session.GetString("lastvisit") != null)
                    HttpContext.Session.Remove("lastvisit");*/
                
            
            return View();
        }

    }
}
