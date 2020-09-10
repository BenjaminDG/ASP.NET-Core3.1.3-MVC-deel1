using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BierenApplication.ViewComponents
{
    public class MijnFooter:ViewComponent
    {
        public IViewComponentResult Invoke(string footerTekst)
        {
            return View((object)footerTekst);
        }
    }
}
