using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Models
{
    public class FixtureModel
    {
        public int id { get; set; }
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
        public Score score { get; set; }
        public DateTime localTime { get; set; }
        public string homeEmblem { get; set; }
        public string awayEmblem { get; set; }
        public string competition { get; set; }
        public string status { get; set; }
        public string homeShort { get; set; }
        public string awayShort { get; set; }
        public string homevShort { get; set; }
        public string awayvShort { get; set; }
    }
}
