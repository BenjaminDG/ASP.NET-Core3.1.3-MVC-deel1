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
using Newtonsoft.Json;

namespace Reisbureau.Controllers
{
    public class HomeController : Controller
    {
        
        private BrochureService _brochureService; 

        public HomeController( BrochureService brochureService)
        {
            _brochureService = brochureService;
            

        }

        public IActionResult Index()
        {

            var brochures = _brochureService.FindAll();
           
            if (Request.Cookies["Voornaam"] == null) { return Redirect("~/Klant/Toevoegen"); }


            else
                ViewBag.Voornaam = Request.Cookies["Voornaam"];
            BrochureViewModel vm = new BrochureViewModel();
            vm.Brochures = _brochureService.FindAll();


            return View(vm);
            
        }

        [HttpGet]
        public IActionResult BrochureToevoegen()
        {
            
            var brochure = new Brochure() ;
            

            return View(brochure);
        }

        [HttpPost]
        public IActionResult BrochureToevoegen(Brochure b)
        {
            if (this.ModelState.IsValid)
            {
                
                
                
                
                
                
                
                _brochureService.Add(b);
                return Redirect("~/") ;

            }
            else return View(b);
        }

        public IActionResult Winkelmandje() 
        {
            
               
            
            return View(); }


         public IActionResult Verwijderen(int id)
        {
             _brochureService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult BrochuresDoorsturen(int id) 
        {
            _brochureService.DeleteAll();
            
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
