using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BierenApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BierenApplication.Controllers
{
    public class BierController : Controller
    {
        public IActionResult Index()
        {
            var bieren = new List<Bier>();
            bieren.Add(new Bier { Id = 0, Naam = "Hoegaarden", Alcohol = 4.9F });
            
            bieren.Add(new Bier{Id = 15, Naam = "Felix", Alcohol = 7 });
            bieren.Add(new Bier { Id = 17, Naam = "Roman", Alcohol = 7.5F });
            return View(bieren);
        }
    }
}
