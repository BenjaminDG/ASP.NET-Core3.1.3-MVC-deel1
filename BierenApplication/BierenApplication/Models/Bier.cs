using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BierenApplication.Models
{
    public class Bier
    {
        [DisplayFormat(DataFormatString ="{0:00}")]
        public int Id { get; set; }
        public string Naam { get; set; }
        [UIHint("kleuren")]
        public float Alcohol { get; set; }
    }
}
