using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace voorbeeld1.Controllers
{
    public class FiliaalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Read(int? id)
        {
            //lees in de database het filiaal waarvan de id gelijk is aan de waarde van de parameter id
            return View();
        }
    }
}
