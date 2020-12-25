using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Models
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string nationality { get; set; }
        public string position { get; set; }
        public int? shirtNumber { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
