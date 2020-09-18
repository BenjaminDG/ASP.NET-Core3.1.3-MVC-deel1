using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BierenApplication.Models;
using Microsoft.AspNetCore.Mvc;
using BierenApplication.Services;
using Newtonsoft.Json;

namespace BierenApplication.Controllers
{
    public class BierController : Controller
    {

        private BierService _bierService;

        public BierController(BierService bierService)
        {
            _bierService = bierService;
        }
        public IActionResult Index()
        {
            var bieren = _bierService.FindAll();
            return View(bieren);
        }

        public IActionResult Verwijderen(int Id)
        {
            var bier = _bierService.Read(Id);
            return View(bier);
        }
        
        public IActionResult Delete(int Id)
        {
            var bier = _bierService.Read(Id);
            this.TempData["bier"] = JsonConvert.SerializeObject(bier);
            _bierService.Delete(Id);
            return RedirectToAction("Verwijderd");
        }

        public IActionResult Verwijderd()
        {
            var bier = JsonConvert.DeserializeObject<Bier>((string)this.TempData["bier"]);
            return View(bier);
        }
        [HttpGet]
        public IActionResult Toevoegen()
        {
            var bier = new Bier();
            return View(bier);
        }

        [HttpPost]
        public IActionResult Toevoegen(Bier b)
        {
            if (this.ModelState.IsValid)
            {
                _bierService.Add(b);
                return RedirectToAction("Index");
            }
            else { return View(b); }
        }



        
    }
}
