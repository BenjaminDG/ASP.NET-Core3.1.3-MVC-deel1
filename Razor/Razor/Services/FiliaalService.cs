using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Services
{
    public class FiliaalService
    {

        public List<Filiaal> FindAll()
        {
            //levert enkel de values op van de dictionary
            return filialen.Values.ToList();
        }
        public Filiaal Read(int id)
        {
            return filialen[id];
        }
        public void Delete(int id)
        {
            filialen.Remove(id);
        }
        private Dictionary<int, Filiaal> filialen = new Dictionary<int, Filiaal>();
        public FiliaalService()
        {
            filialen[1] = new Filiaal
            {
                Id = 1,
                Gebouwd = new DateTime(2003, 1, 1),
                Waarde = 2000000,
                Eigenaar = Eigenaar.Gehuurd
            };

            filialen[2] = new Filiaal
            {
                Id = 2,
                Naam = "Wondelgem",
                Gebouwd = new DateTime(1979, 1, 1),
                Waarde = 2500000,
                Eigenaar = Eigenaar.Gehuurd
            };
            filialen[3] = new Filiaal
            {
                Id = 3,
                Naam = "Haasrode",
                Gebouwd = new DateTime(1976, 1, 1),
                Waarde = 1000000,
                Eigenaar = Eigenaar.Eigendom
            };
            filialen[4] = new Filiaal
            {
                Id = 4,
                Naam = "Wevelgem",
                Gebouwd = new DateTime(1981, 1, 1),
                Waarde = 1600000,
                Eigenaar = Eigenaar.Eigendom
            };
            filialen[5] = new Filiaal
            {
                Id = 5,
                Naam = "Genk",
                Gebouwd = new DateTime(1990, 1, 1),
                Waarde = 4000000,
                Eigenaar = Eigenaar.Gehuurd
            };


           
        }
    }
}
