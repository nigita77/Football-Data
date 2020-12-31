using System;
using System.Collections.Generic;

namespace Project01.Models
{
    public class SquadMember
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string countryOfBirth { get; set; }
        public string nationality { get; set; }
        public string role { get; set; }
    }
    public class Area
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class Competition
    {
        public int id { get; set; }
        public Area area { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string plan { get; set; }
        public DateTime lastUpdated { get; set; }
    }
    public class Season
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int currentMatchday { get; set; }
        public string winner { get; set; }
    }
    public class Odds
    {
        public string msg { get; set; }
    }
    public class FullTime
    {
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
    }

    public class HalfTime
    {
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
    }
    public class ExtraTime
    {
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
    }

    public class Penalties
    {
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
    }
    public class Score
    {
        public string winner { get; set; }
        public string duration { get; set; }
        public FullTime fullTime { get; set; }
        public HalfTime halfTime { get; set; }
        public ExtraTime extraTime { get; set; }
        public Penalties penalties { get; set; }
    }

    public class HomeTeam
    {
        public int id { get; set; }
        public string name { get; set; }
        public SquadMember coach { get; set; }
        public Player captain { get; set; }
        public List<Player> lineup { get; set; }
        public List<Player> bench { get; set; }
    }
    public class AwayTeam
    {
        public int id { get; set; }
        public string name { get; set; }
        public SquadMember coach { get; set; }
        public Player captain { get; set; }
        public List<Player> lineup { get; set; }
        public List<Player> bench { get; set; }
    }
    public class Referee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string nationality { get; set; }
    }

    public class Goal
    {
        public int minute { get; set; }
        public string extraTime { get; set; }
        public string type { get; set; }
        public Team team { get; set; }
        public Player scorer { get; set; }
        public Player assist { get; set; }
    }

    public class Booking
    {
        public int minute { get; set; }
        public Team team { get; set; }
        public Player player { get; set; }
        public string card { get; set; }
    }

    public class Substitution
    {
        public int minute { get; set; }
        public Team team { get; set; }
        public Player playerOut { get; set; }
        public Player playerIn { get; set; }
    }

    public class HeadtoHead
    {
        public int numberOfMatches { get; set; }
        public int totalGoals { get; set; }
        public Dictionary<string, string> homeTeam { get; set; }
        public Dictionary<string, string> awayTeam { get; set; }
    }

    public class Match
    {
        public int id { get; set; }
        public Season season { get; set; }
        public DateTime utcDate { get; set; }
        public string status { get; set; }
        public string matchday  { get; set; }
        public string stage { get; set; }
        public string group { get; set; }
        public DateTime lastUpdated { get; set; }
        public Odds odds { get; set; }
        public Score score { get; set; }
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
        public List<Goal> goals { get; set; }
        public List<Booking> bookings { get; set; }
        public List<Substitution> substituitions { get; set; }
        public List<Referee> referees { get; set; }
    }

    public class MatchDetail
    {
        public HeadtoHead head2head { get; set; }
        public Match match { get; set; }
    }
    public class MatchesModel
    {
        public int count { get; set; }
        public Dictionary<Object,Object> filters { get; set; }
        public Competition competition { get; set; }
        public List<Match> matches { get; set; }
    }
}