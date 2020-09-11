using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{
    public class Persoon
    {
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }

        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime InDienst { get; set; }
        [DisplayFormat(DataFormatString ="{0:€#,##0.00}")]
        public decimal Wedde { get; set; }
    }
}
