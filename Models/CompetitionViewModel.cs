using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Models
{
    public class CompetitionViewModel
    {
        public StandingsModel standings { get; set; }
        public TeamsModel teams { get; set; }
        public MatchesModel  matches{ get; set; }
        public ScorerModel scorer { get; set; }
    }
}
