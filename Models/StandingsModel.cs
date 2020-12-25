using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Models
{
    public class Table
    {
        public int position  { get; set; }
        public Team team { get; set; }
        public int playedGames { get; set; }
        public string form { get; set; }
        public int won { get; set; }
        public int draw { get; set; }
        public int lost { get; set; }
        public int points { get; set; }
        public int goalsFor { get; set; }
        public int goalsAgainst { get; set; }
        public int goalDifference { get; set; }
    }
    public class Standings
    {
        public string stage { get; set; }
        public string type { get; set; }
        public string group { get; set; }
        public List<Table> table { get; set; }
    }
    public class StandingsModel
    {
        public Dictionary<string, string> filters { get; set; }
        public Competition competition { get; set; }
        public Season season { get; set; }
        public List<Standings> standings { get; set; }
    }   
}
