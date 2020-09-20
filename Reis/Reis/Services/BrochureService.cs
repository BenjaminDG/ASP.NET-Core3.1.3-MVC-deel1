using Reis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Reis.Services
{
    public class BrochureService
    {
        private Dictionary<int, Brochure> brochures = new Dictionary<int, Brochure>();
        public BrochureService()
        {
            brochures[1] = new Brochure { ID = 1, Naam = "Hawai" };
        }

        public List<Brochure> FindAll()
        {
            //levert enkel de values op van de dictionary
            return brochures.Values.ToList();
        }
        public Brochure Read(int id)
        {
            return brochures[id];
        }
        public void Delete(int id)
        {
            brochures.Remove(id);
        }
        public Brochure FindByID(int id)
        {
            return brochures[id];
        }
        public void Add(Brochure b)
        {
            b.ID = brochures.Keys.Max() + 1;
            brochures.Add(b.ID, b);
        }
        
    }
}
