using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeerOverControllers.Controllers
{
    public class WerknemerController : Controller
    {
        public IActionResult Index()
        {
            return File(@"images\happy.png", "image/png");
        }

        [NonAction]
        public string HuidigeDatum()
        {
            return DateTime.Now.ToShortDateString();
        }

        public IActionResult Read(int id)
        {
            return View();
        }

        public IActionResult VerdubbelDeWeddes()
        {
            //update in de database
            //....
            return Redirect("~/Werknemer/WeddesAangepast");
        }
        public IActionResult WeddesAangepast()
        {
            return View();
        }

        public IActionResult Even(int id)
        {
            if (id % 2 == 0)
            {
                return View();
            }
            else
            {
                return Redirect("~/werknemer/oneven");
            }

            
        }
        public IActionResult oneven() 
        {
            return View();
        }

    }
}
