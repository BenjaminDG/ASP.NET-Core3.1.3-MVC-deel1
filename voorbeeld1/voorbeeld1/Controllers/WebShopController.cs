using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace voorbeeld1.Controllers
{
    public class WebShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registreer()
        {
            return View();
        }
        public IActionResult WinkelMandje() 
        {
            return View(); 
        }
    }
}
