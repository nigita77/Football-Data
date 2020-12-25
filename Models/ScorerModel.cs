using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Models
{
    public class Scorer
    {
        public Player player { get; set; }
        public Team team { get; set; }
        public int numberOfGoals { get; set; }
    }
    public class ScorerModel
    {
        public int count { get; set; }
        public Dictionary<string,string> filters { get; set; }
        public Competition competition { get; set; }
        public Season season { get; set; }
        public List<Scorer> scorers { get; set; }
    }
}
