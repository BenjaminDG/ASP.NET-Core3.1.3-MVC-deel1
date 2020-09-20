using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Reis.Models;
using Reis.Services;

namespace Reis.Controllers
{
    public class HomeController : Controller
    {
        private BrochureService _brochureService;

        public HomeController(BrochureService brochureService)
        {
            _brochureService =brochureService;
        }

        public IActionResult Index()
        {
           
            return View(_brochureService.FindAll());
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
                return Redirect("Index");
            }
            else { return RedirectToAction("Index"); }
        }
        /*
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var brochure = _brochureService.Read(id);
            this.TempData["brochure"] = JsonConvert.SerializeObject(brochure);
            _brochureService.Delete(id);
            return Redirect("~/Home/Verwijderd");
        }
        
        [HttpGet]
        public IActionResult VerwijderBrochure(int id)
        {
            return View(_brochureService.FindByID(id));
        }*/

        public IActionResult Verwijderen(int id)
        {
             _brochureService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult AlleBrochure()
        {
            
            
            return View();
        }


        public IActionResult BrochuresDoorsturen()
        {
            
            return RedirectToAction("Index");
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
    }
}
