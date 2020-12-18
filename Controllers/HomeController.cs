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

namespace Project01.Controllers
{
    public class HomeController : Controller
    {
        private const string Value = "5f0f87aa7a314f9db4722f38c156d3d3";
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

        private async void apiCall()
        {
            apiCalled = true;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-Auth-Token", Value);
                UriBuilder uri = new UriBuilder("https://api.football-data.org/");
                uri.Path = "v2/competitions/CL/matches";
                using (HttpResponseMessage response = await httpClient.GetAsync(uri.ToString()))
                {
                    string apiResopnse = await response.Content.ReadAsStringAsync();
                    clMatches = JsonConvert.DeserializeObject<MatchesModel>(apiResopnse);
                }

                uri.Path = "v2/competitions/PL/matches";
                using (HttpResponseMessage response = await httpClient.GetAsync(uri.ToString()))
                {
                    string apiResopnse = await response.Content.ReadAsStringAsync();
                    plMatches = JsonConvert.DeserializeObject<MatchesModel>(apiResopnse);
                }

                uri.Path = "v2/competitions/PD/matches";
                using (HttpResponseMessage response = await httpClient.GetAsync(uri.ToString()))
                {
                    string apiResopnse = await response.Content.ReadAsStringAsync();
                    pdMatches = JsonConvert.DeserializeObject<MatchesModel>(apiResopnse);
                }

                uri.Path = "v2/competitions/CL/teams";
                using (HttpResponseMessage response = await httpClient.GetAsync(uri.ToString()))
                {
                    string apiResopnse = await response.Content.ReadAsStringAsync();
                    clTeams = JsonConvert.DeserializeObject<TeamsModel>(apiResopnse);
                }

                uri.Path = "v2/competitions/PL/teams";
                using (HttpResponseMessage response = await httpClient.GetAsync(uri.ToString()))
                {
                    string apiResopnse = await response.Content.ReadAsStringAsync();
                    plTeams = JsonConvert.DeserializeObject<TeamsModel>(apiResopnse);
                }

                uri.Path = "v2/competitions/PD/teams";
                using (HttpResponseMessage response = await httpClient.GetAsync(uri.ToString()))
                {
                    string apiResopnse = await response.Content.ReadAsStringAsync();
                    pdTeams = JsonConvert.DeserializeObject<TeamsModel>(apiResopnse);
                }
            }
        }
        public IActionResult Index(DateTime? id)
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
                apiCall();
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
