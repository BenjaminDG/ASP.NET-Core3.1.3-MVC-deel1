using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ViewComponents.ViewComponents
{
    public class Reclame: ViewComponent
    {
        static string[] powerbars = { "mars", "bounty", "snickers", "twix" };
        public IViewComponentResult Invoke(string tekst, bool html)
        {   if (html)
                return new HtmlContentViewComponentResult(new HtmlString(tekst));
            else return Content(tekst);
        }
    }
}
