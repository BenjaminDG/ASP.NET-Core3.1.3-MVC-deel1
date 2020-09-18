using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Razor.Models
{
    public class OpslagViewModel
    {
        [Display(Name ="Van wedde:")]
        [Required(ErrorMessage ="Van Wedde is een verplicht veld")]
        public decimal? VanWedde { get; set; }

        [Display(Name = "Tot wedde:")]
        [Required(ErrorMessage = "tot wedde is en verplicht veld ")]
        public decimal? TotWedde { get; set; }
        [Display(Name = "Percentage:")]
        [Required(ErrorMessage ="Percentage is een verplicht veld")]
        [Range(0,100,ErrorMessage ="de min en max waarden voor percentages zijn zijn : {1} en {2}")]
        public decimal Percentage { get; set; }
    }
}
