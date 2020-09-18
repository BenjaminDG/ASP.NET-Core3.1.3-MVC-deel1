using BierenApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BierenApplication.Services
{
    public class BierService
    {

        private Dictionary<int, Bier> bieren = new Dictionary<int, Bier>();
        public BierService()
        {
            bieren[1] = new Bier
            {
                Id = 1,
                Naam = "Hoegaarden",
                Alcohol = 4.9F

            };

            bieren[2] = new Bier
            {
                Id = 2,
                Naam = "Felix",
                Alcohol = 7
            };
            bieren[3] = new Bier
            {
                Id = 3,
                Naam = "Roman",
                Alcohol = 7.5F
            };

        }
        public List<Bier> FindAll()
        {
            return bieren.Values.ToList();
        }
        public Bier Read(int id) { return bieren[id]; }
        public void Delete(int id) {  bieren.Remove(id); }

        public void Add(Bier b)
        {
            b.Id = bieren.Keys.Max() + 1;
            bieren.Add(b.Id, b);
        }
    }
}
