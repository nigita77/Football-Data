using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Models
{

    public class Team
    {
        public int id { get; set; }
        public Area area { get; set; }
        public List<Competition> activeCompetitions { get; set; }

        public string name { get; set; }
        public string shortName { get; set; }
        public string tla { get; set; }
        public string crestUrl { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string email { get; set; }
        public string founded { get; set; }
        public string clubColors { get; set; }
        public string venue { get; set; }
        public List<Player> squad { get; set; }
        public DateTime lastUpdated { get; set; }
    }
    public class TeamsModel
    {
        public int count { get; set; }
        public Dictionary<string, string> filters { get; set; }
        public Competition competition { get; set; }
        public Season season { get; set; }
        public List<Team> teams { get; set; }
    }
}
