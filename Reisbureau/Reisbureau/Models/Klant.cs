using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Reisbureau.Models
{
    public class Klant
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Dit is een verplicht veld!")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld!")]
        public string Voornaam { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld!")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld!")]
        [Range(1000, 9999, ErrorMessage =" min-en maxwaarden zijn :{1} en {2}")]
        public string Postcode { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld!")]
        public string Gemeente { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld!")]
        [DataType(DataType.PhoneNumber)]
        public string Telefoon { get; set; }
    }
}
