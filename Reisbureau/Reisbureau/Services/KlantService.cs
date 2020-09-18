using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reisbureau.Models;
namespace Reisbureau.Services
{
    public class KlantService
    {
        private Dictionary<int, Klant> klanten = new Dictionary<int, Klant>
        {
            };

        public List<Klant> FindAll() { return klanten.Values.ToList(); }
        public Klant FindByID(int id) { return klanten[id]; }
        public void Add(Klant k)
        {
            if (klanten.Count!=0) { 
            k.ID = klanten.Keys.Max() + 1;
            klanten.Add(k.ID, k);
            }
            else { k.ID = 1; klanten.Add(k.ID, k); }
        }


    }
}
