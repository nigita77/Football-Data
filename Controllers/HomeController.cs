using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project01.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;

namespace Project01.Controllers
{
    public class HomeController : Controller
    {
        private const string Value1 = "5f0f87aa7a314f9db4722f38c156d3d3";
        private const string Value2 = "1894fa46cc8b4324a512d5d45e6960a4";
        private const string API = "https://api.football-data.org/";
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        static bool apiCalled = false;
        static MatchesModel clMatches;
        static MatchesModel plMatches;
        static MatchesModel pdMatches;

        static TeamsModel clTeams;
        static TeamsModel plTeams;
        static TeamsModel pdTeams;

        static StandingsModel clStanding;
        static StandingsModel plStanding;
        static StandingsModel pdStanding;

        static ScorerModel clScorers;
        static ScorerModel plScorers;
        static ScorerModel pdScorers;

        private static HttpClient httpClient = new HttpClient();

        private async Task<bool> apiCall()
        {
            string[] matchPaths = { "v2/competitions/CL/matches" , "v2/competitions/PL/matches", "v2/competitions/PD/matches" };
            string[] teamPaths = { "v2/competitions/CL/teams", "v2/competitions/PL/teams", "v2/competitions/PD/teams" };
            string[] standingPaths = { "v2/competitions/CL/standings", "v2/competitions/PL/standings", "v2/competitions/PD/standings" };
            string[] scorerPaths = { "v2/competitions/CL/scorers", "v2/competitions/PL/scorers", "v2/competitions/PD/scorers" };

            IEnumerable<MatchesModel> matches = await ApiMatchModelAsync(matchPaths);
            IEnumerable<TeamsModel> teams = await ApiTeamModelAsync(teamPaths);
            IEnumerable<StandingsModel> standings = await ApiStandingModelAsync(standingPaths);
            IEnumerable<ScorerModel> scorers = await ApiScorerModelAsync(scorerPaths);

            clMatches = matches.Where(match => match.competition.id == 2001).FirstOrDefault();
            plMatches = matches.Where(match => match.competition.id == 2021).FirstOrDefault();
            pdMatches = matches.Where(match => match.competition.id == 2014).FirstOrDefault();

            clTeams = teams.Where(team => team.competition.id == 2001).FirstOrDefault();
            plTeams = teams.Where(team => team.competition.id == 2021).FirstOrDefault();
            pdTeams = teams.Where(team => team.competition.id == 2014).FirstOrDefault();

            clStanding = standings.Where(standing => standing.competition.id == 2001).FirstOrDefault();
            plStanding = standings.Where(standing => standing.competition.id == 2021).FirstOrDefault();
            pdStanding = standings.Where(standing => standing.competition.id == 2014).FirstOrDefault();

            clScorers = scorers.Where(scorer => scorer.competition.id == 2001).FirstOrDefault();
            plScorers = scorers.Where(scorer => scorer.competition.id == 2021).FirstOrDefault();
            pdScorers = scorers.Where(scorer => scorer.competition.id == 2014).FirstOrDefault();

            return true;
        }

        private async Task<IEnumerable<MatchesModel>> ApiMatchModelAsync(string [] uris)
        {
            httpClient.DefaultRequestHeaders.Add("X-Auth-Token", Value1);
            for (int i = 0; i < uris.Length; i++) { uris[i] = API + uris[i]; }
            var request = uris.Select(url => httpClient.GetAsync(url)).ToList();

            await Task.WhenAll(request);

            var responses = request.Select(task => task.Result);

            List<MatchesModel> responseModels = new List<MatchesModel>();
            foreach (var r in responses)
            {
                var s = await r.Content.ReadAsStringAsync();
                responseModels.Add(JsonConvert.DeserializeObject<MatchesModel>(s));
            }
            httpClient.DefaultRequestHeaders.Remove("X-Auth-Token");
            return responseModels;
        }

        private async Task<IEnumerable<TeamsModel>> ApiTeamModelAsync(string[] uris)
        {
            httpClient.DefaultRequestHeaders.Add("X-Auth-Token", Value1);
            for (int i = 0; i < uris.Length; i++) { uris[i] = API + uris[i]; }
            var request = uris.Select(url => httpClient.GetAsync(url)).ToList();

            await Task.WhenAll(request);

            var responses = request.Select(task => task.Result);

            List<TeamsModel> responseModels = new List<TeamsModel>();
            foreach (var r in responses)
            {
                var s = await r.Content.ReadAsStringAsync();
                responseModels.Add(JsonConvert.DeserializeObject<TeamsModel>(s));
            }
            httpClient.DefaultRequestHeaders.Remove("X-Auth-Token");
            return responseModels;
        }

        private async Task<IEnumerable<StandingsModel>> ApiStandingModelAsync(string[] uris)
        {
            httpClient.DefaultRequestHeaders.Add("X-Auth-Token", Value1);
            for (int i = 0; i < uris.Length; i++) { uris[i] = API + uris[i]; }
            var request = uris.Select(url => httpClient.GetAsync(url)).ToList();

            await Task.WhenAll(request);

            var responses = request.Select(task => task.Result);

            List<StandingsModel> responseModels = new List<StandingsModel>();
            foreach (var r in responses)
            {
                var s = await r.Content.ReadAsStringAsync();
                responseModels.Add(JsonConvert.DeserializeObject<StandingsModel>(s));
            }
            httpClient.DefaultRequestHeaders.Remove("X-Auth-Token");
            return responseModels;
        }

        private async Task<IEnumerable<ScorerModel>> ApiScorerModelAsync(string[] uris)
        {
            httpClient.DefaultRequestHeaders.Add("X-Auth-Token", Value2);
            for (int i = 0; i < uris.Length; i++) { uris[i] = API + uris[i]; }
            var request = uris.Select(url => httpClient.GetAsync(url)).ToList();

            await Task.WhenAll(request);

            var responses = request.Select(task => task.Result);

            List<ScorerModel> responseModels = new List<ScorerModel>();
            foreach (var r in responses)
            {
                var s = await r.Content.ReadAsStringAsync();
                responseModels.Add(JsonConvert.DeserializeObject<ScorerModel>(s));
            }
            httpClient.DefaultRequestHeaders.Remove("X-Auth-Token");
            return responseModels;
        }
        public async Task<IActionResult> Index(DateTime? id)
        {
            DateTime temp;
            if (id == null)
            {
                temp = DateTime.Now;
            }
            else
            {
                temp = id.GetValueOrDefault();
            }
            if (apiCalled == false)
            {
                apiCalled = await apiCall();
            }
            ViewData["date"] = temp.Date.ToString("MMM dd");
            ViewData["nextDate"] = temp.AddDays(1).ToString("yyyy-MM-dd");
            ViewData["prevDate"] = temp.AddDays(-1).ToString("yyyy-MM-dd");
            var clToday = from match in clMatches.matches
                          where match.utcDate.ToLocalTime().Date == temp.Date
                          select match;
            var plToday = from match in plMatches.matches
                          where match.utcDate.ToLocalTime().Date == temp.Date
                          select match;
            var pdToday = from match in pdMatches.matches
                          where match.utcDate.ToLocalTime().Date == temp.Date
                          select match;
            List<FixtureModel> fixtures1 = new List<FixtureModel>();
            foreach (var match in clToday)
            {
                FixtureModel fixture = new FixtureModel();
                fixture.id = match.id;
                fixture.homeTeam = match.homeTeam;
                fixture.awayTeam = match.awayTeam;
                fixture.score = match.score;
                fixture.localTime = match.utcDate.ToLocalTime();
                var home = from team in clTeams.teams
                           where team.id == match.homeTeam.id
                           select team;
                var away = from team in clTeams.teams
                           where team.id == match.awayTeam.id
                           select team;
                List<Team> homeDetail = home.ToList<Team>();
                List<Team> awayDetail = away.ToList<Team>();
                fixture.homeEmblem = homeDetail[0].crestUrl;
                fixture.awayEmblem = awayDetail[0].crestUrl;
                fixture.competition = "CL";
                fixture.status = match.status;
                fixture.homeShort = homeDetail[0].shortName;
                fixture.awayShort = awayDetail[0].shortName;
                fixture.homevShort = homeDetail[0].tla;
                fixture.awayvShort = awayDetail[0].tla;
                fixtures1.Add(fixture);
            }
            foreach (var match in plToday)
            {
                FixtureModel fixture = new FixtureModel();
                fixture.id = match.id;
                fixture.homeTeam = match.homeTeam;
                fixture.awayTeam = match.awayTeam;
                fixture.score = match.score;
                fixture.localTime = match.utcDate.ToLocalTime();
                var home = from team in plTeams.teams
                           where team.id == match.homeTeam.id
                           select team;
                var away = from team in plTeams.teams
                           where team.id == match.awayTeam.id
                           select team;
                List<Team> homeDetail = home.ToList<Team>();
                List<Team> awayDetail = away.ToList<Team>();
                fixture.homeEmblem = homeDetail[0].crestUrl;
                fixture.awayEmblem = awayDetail[0].crestUrl;
                fixture.competition = "PL";
                fixture.status = match.status;
                fixture.homeShort = homeDetail[0].shortName;
                fixture.awayShort = awayDetail[0].shortName;
                fixture.homevShort = homeDetail[0].tla;
                fixture.awayvShort = awayDetail[0].tla;
                fixtures1.Add(fixture);
            }
            foreach (var match in pdToday)
            {
                FixtureModel fixture = new FixtureModel();
                fixture.id = match.id;
                fixture.homeTeam = match.homeTeam;
                fixture.awayTeam = match.awayTeam;
                fixture.score = match.score;
                fixture.localTime = match.utcDate.ToLocalTime();
                var home = from team in pdTeams.teams
                           where team.id == match.homeTeam.id
                           select team;
                var away = from team in pdTeams.teams
                           where team.id == match.awayTeam.id
                           select team;
                List<Team> homeDetail = home.ToList<Team>();
                List<Team> awayDetail = away.ToList<Team>();
                fixture.homeEmblem = homeDetail[0].crestUrl;
                fixture.awayEmblem = awayDetail[0].crestUrl;
                fixture.competition = "PD";
                fixture.status = match.status;
                fixture.homeShort = homeDetail[0].shortName;
                fixture.awayShort = awayDetail[0].shortName;
                fixture.homevShort = homeDetail[0].tla;
                fixture.awayvShort = awayDetail[0].tla;
                fixtures1.Add(fixture);
            }
            return View(fixtures1);
        }

        [HttpPost]
        public IActionResult Index(DateTime dateto, bool isBool)
        {
            return RedirectToAction(nameof(Index), "Home", new { id = dateto.ToString("yyyy-MM-dd") });
        }

        public async Task<IActionResult> Compete(string id)
        {
            if (apiCalled == false)
            {
                apiCalled = await apiCall();
            }

            CompetitionViewModel com = new CompetitionViewModel(); 
            if (id == "CL")
            {
                com.matches = clMatches;
                com.teams = clTeams;
                com.standings = clStanding;
                com.scorer = clScorers;
                return View(com);
            }

            else if (id == "PL")
            {
                com.matches = plMatches;
                com.teams = plTeams;
                com.standings = plStanding;
                com.scorer = plScorers;
                return View(com);
            }

            else if (id == "PD")
            {
                com.matches = pdMatches;
                com.teams = pdTeams;
                com.standings = pdStanding;
                com.scorer = pdScorers;
                return View(com);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Search (string searchString)
        {
            SearchViewModel search = new SearchViewModel();
            StringComparison compare = StringComparison.CurrentCultureIgnoreCase;
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            search.searchMatches.AddRange(clMatches.matches.Where(x => x.homeTeam.name.Contains(searchString, compare) || x.awayTeam.name.Contains(searchString,compare))); // Angel
            search.searchMatches.AddRange(plMatches.matches.Where(x => x.homeTeam.name.Contains(searchString, compare) || x.awayTeam.name.Contains(searchString, compare)));
            search.searchMatches.AddRange(pdMatches.matches.Where(x => x.homeTeam.name.Contains(searchString, compare) || x.awayTeam.name.Contains(searchString, compare)));

            search.searchTeams.AddRange(clTeams.teams.Where(x => x.name.Contains(searchString, compare)));
            search.searchTeams.AddRange(plTeams.teams.Where(x => x.name.Contains(searchString, compare)));
            search.searchTeams.AddRange(pdTeams.teams.Where(x => x.name.Contains(searchString, compare)));

            search.allTeams.AddRange(clTeams.teams);
            search.allTeams.AddRange(plTeams.teams);
            search.allTeams.AddRange(pdTeams.teams);
            return View(search);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
