using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Razor.Models;
using Razor.Services;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        private FiliaalService _filiaalService;
        public HomeController(FiliaalService filiaalService)
        {
            _filiaalService = filiaalService;
        }


        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */
        public IActionResult Index()
        {
            return View(new Persoon { Voornaam = "Eddy", Familienaam = "Wally" });
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

        public IActionResult Palindroom(string woord)
        {
            char[] omgekeerd = woord.ToCharArray();
            Array.Reverse(omgekeerd);
            string achterstevoren = new string(omgekeerd);
            if (woord == achterstevoren)
                ViewBag.palindroom = true;
            else ViewBag.palindoom = false;

            ViewBag.ingetiktwoord = woord;
            return View();

        }

        public IActionResult Vestigingen()
        {
            Hoofzetel deHoofdZetel = new Hoofzetel
            {
                Straat = "keizerlaan",
                Huisnummer = "11",
                Postcode = "1000",
                Gemeente = "Brussel"
            };
            ViewBag.deHoofdzetel = deHoofdZetel;

            var recentVerwijderdFiliaal = (string)this.TempData["filiaal"]; 
if (recentVerwijderdFiliaal != null)
                ViewBag.recenteVerwijdering = JsonConvert.DeserializeObject<Filiaal>(recentVerwijderdFiliaal).Naam;


            return View(_filiaalService.FindAll());
        }
        [ActionName("Werknemerslijst")]
        public IActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();
            werknemers.Add(new Werknemer { Voornaam = "steven", Wedde = 1000, InDienst = DateTime.Today });
            werknemers.Add(new Werknemer { Voornaam = "Prosper", Wedde = 2000, InDienst = DateTime.Today.AddDays(2) });
            return View("AlleWerknemers",werknemers);
        }

        public IActionResult Verwijderen(int id)
        {
            var filiaal = _filiaalService.Read(id);
            return View(filiaal);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var filiaal = _filiaalService.Read(id);
            this.TempData["filiaal"] = JsonConvert.SerializeObject(filiaal);
            _filiaalService.Delete(id);
            return Redirect("~/Home/Verwijderd");
        }

        public IActionResult Verwijderd()
        {
            var verwijderdFiliaal = (string)this.TempData["filiaal"];
            this.TempData.Keep("filiaal");
            if (verwijderdFiliaal != null)
                return View(JsonConvert.DeserializeObject<Filiaal>(verwijderdFiliaal));
            else
                return RedirectToAction("Vestigingen");
        }
    }
}
