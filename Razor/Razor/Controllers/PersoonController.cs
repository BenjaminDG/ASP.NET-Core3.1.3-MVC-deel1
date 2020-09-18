using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Services;
using Razor.Models;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Globalization;
namespace Razor.Controllers
{
    public class PersoonController : Controller
    {

        private PersoonService _persoonService;
        public PersoonController(PersoonService persoonService)
        {
            _persoonService = persoonService;
        }
        public IActionResult Index()
        {
            return View(_persoonService.FindAll());
        }

        public IActionResult VerwijderForm(int Id)
        {
            return View(_persoonService.FindByID(Id));
        }

        [HttpPost]
        public IActionResult Verwijderen(int id)
        {
            _persoonService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new OpslagViewModel();
            opslagViewModel.Percentage = 10m; 
            return View(opslagViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            /*   _persoonService.Opslag(opslagVieuwModel.VanWedde.Value, opslagVieuwModel.TotWedde.Value, opslagVieuwModel.Percentage);
               return  RedirectToAction("Index");*/
            if (this.ModelState.IsValid)
            {
                //geen validatiefouten
                _persoonService.Opslag(opslagViewModel.VanWedde.Value,
                opslagViewModel.TotWedde.Value, opslagViewModel.Percentage);
                return RedirectToAction("Index");
            }
            else
            {
                //wel validatiefouten
                return View(opslagViewModel);
            }



        }
        [HttpGet]
        public IActionResult VanTotWedde()
        {
            var vanTotWeddeViewModel = new VanTotWeddeViewModel();
            return View(vanTotWeddeViewModel);
        }

        [HttpGet]
        public IActionResult VanTotWeddeResultaat(VanTotWeddeViewModel vanTotWeddeViewModel)
        {
            if (this.ModelState.IsValid)
            {

                var lijst =_persoonService.VanTotWedde(
               
                    vanTotWeddeViewModel.VanWedde.Value,
                    vanTotWeddeViewModel.TotWedde.Value);
                if ( lijst.Count <= 3)
                {
                    vanTotWeddeViewModel.Personen = lijst;
                }
                else
                {
                    this.ModelState.AddModelError("", "Te veel resultaten");
                }
            }
            return View("VanTotWedde", vanTotWeddeViewModel);
        }

        [HttpGet]
        public IActionResult Toevoegen()
        {
            var persoon = new Persoon();
            persoon.Score = 1;
            persoon.Geboren = DateTime.Today;
            return View(persoon);
        }

        [HttpPost]
        public IActionResult Toevoegen(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Add(p);
                return RedirectToAction("Index");
            }
            else
                return View(p);
        }

        public IActionResult EditForm(int id)
        {
            return View(_persoonService.FindByID(id));
        }
        public IActionResult Edit(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Update(p);
                return RedirectToAction("Index");
            }
            else { return View("EditForm", p); }
        }

        public IActionResult ValideerGeboortedatum(string Geboren)
        {
            DateTime doorgegevenDatum;
            //staat invoer in Belgisch formaat?
            var nlDate = DateTime.TryParseExact(Geboren, "d/MM/yyyy", CultureInfo.GetCultureInfo("nl-BE"), DateTimeStyles.None, out doorgegevenDatum);
            //staat invoer inUS formaat
            var ukDate = DateTime.TryParseExact(Geboren, "yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out doorgegevenDatum);
            // geldig datumformaat?
            if (!nlDate && !ukDate)
            {
                return Json("Gelieve een geldig datum in te voeren (dd/mm/jjjj) !");
            }
            //datum in het verleden?
            else if(DateTime.Now < doorgegevenDatum)
            {
                return Json("Voer een datum uit het verleden in !");
            }
            else
            {
                return Json(true);
            }
        }

     
    }

}
