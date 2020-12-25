using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.Models
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
            searchMatches = new List<Match>();
            searchTeams = new List<Team>();
            searchCompetition = new List<Competition>();
            allTeams = new List<Team>();
        }
        public List<Match> searchMatches { get; set; }
        public List<Team> searchTeams { get; set; }
        public List<Competition> searchCompetition { get; set; }
        public List<Team> allTeams { get; set; }
    }
}
