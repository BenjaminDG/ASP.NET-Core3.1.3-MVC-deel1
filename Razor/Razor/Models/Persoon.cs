using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{
    [WeddeScore]
    public class Persoon
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        [OnevenTussenTweeGrenzen(1, 5, ErrorMessage ="Enkele oneven scores tussen{1} en {2} !")]
        public int Score { get; set; }
        
        
        [DisplayFormat(DataFormatString ="{0:€#,##0.00}")]
        public decimal Wedde { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage =
"Het wachtwoord bevat min. {2}, max. {1} tekens")]

        public string Paswoord { get; set; }
        [Required]
        [Compare("Paswoord", ErrorMessage ="{0} verschilt van {1}")]
        [DataType(DataType.Password)]
        public string HerhaalPaswoord { get; set; }

        [DisplayFormat(DataFormatString ="{0:d}", ApplyFormatInEditMode =true)]
        [DataType(DataType.Date)]
        [Remote("ValideerGeboortedatum", "Persoon")]
        //[Verleden(ErrorMessage="Geboortedatum  moet in het verleden liggen")]
        public DateTime Geboren { get; set; }
        public bool Gehuwd { get; set; }
        public string Opmerkingen { get; set; }

        public Geslacht Geslacht { get; set; }
        /*public DateTime InDienst { get; set; }*/
        
        
    }
}
