using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Toevoegen(Klant k)
        {
            if (this.ModelState.IsValid)
            {
                _klantService.Add(k);
                return Redirect("~/");
                    //("/Index");
            }
            else
                return View(k);
        }
    }
}
