using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Models
{
    public class TeamViewModel
    {
        public TeamViewModel()
        {
            matches = new List<Match>();
            activeCompetition = new List<Competition>();
        }
        public Team team { get; set; }
        public List<Match> matches { get; set; }
        public List<Competition> activeCompetition { get; set; }
        public List<Team> allTeams { get; set; }
    }
}
