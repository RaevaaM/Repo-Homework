using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDataAccess.DataModels
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }
        public int BreedId { get; set; }
        public string Breed { get; set; }
    }
}
