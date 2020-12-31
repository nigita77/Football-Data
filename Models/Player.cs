using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Models
{
    public class Player: SquadMember
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int? shirtNumber { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
