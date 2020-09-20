using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Reisbureau.Models;
using Reisbureau.Services;

namespace Reisbureau.Controllers
{
    public class KlantController : Controller
    {
        private KlantService _klantService;
        public KlantController(KlantService klantService) { _klantService = klantService; }
        public IActionResult Index()
        {
            return View(_klantService.FindAll());
        }

        [HttpGet]
        public IActionResult Toevoegen() 
        {
            var klant = new Klant();
            return View(klant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Toevoegen(Klant k)
        {
            string VoornaamCookie = $"{k.Voornaam}";
            if (this.ModelState.IsValid)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Append("Voornaam", VoornaamCookie, option);
                ViewBag.Voornaam = VoornaamCookie;

                _klantService.Add(k);
                return Redirect("~/");
                    
            }
            else
                return View(k);
        }
    }
}
