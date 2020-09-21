using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reisbureau.Models;

namespace Reisbureau.Services
{
    public class BrochureService
    {
        private Dictionary<int, Brochure> brochures = new Dictionary<int, Brochure>();
        public BrochureService() {  }
       

        public List<Brochure> FindAll() { return brochures.Values.ToList(); }
        public Brochure Read(int id) { return brochures[id]; }
        public void Delete(int id) { brochures.Remove(id); }
        public void DeleteAll( ) {   brochures.Clear(); } 
        public Brochure FindByID(int id) { return brochures[id]; }
        public void Add(Brochure b)
        {
            if (brochures.Count != 0) { 
            b.ID = brochures.Keys.Max() + 1;
            brochures.Add(b.ID, b);
            }
            else
            {
                b.ID = 1;
                brochures.Add(b.ID, b);
            }
        }

    }
}
