using System;
using System.Collections.Generic;

namespace F1Calendar
{
    public class DriverStanding
    {
        public string position { get; set; }
        public string positionText { get; set; }
        public string points { get; set; }
        public string wins { get; set; }
        public Driver Driver { get; set; }
        public List<Constructor> Constructors { get; set; }
    }

     public class ConstructorStanding
    {
        public string position { get; set; }
        public string positionText { get; set; }
        public string points { get; set; }
        public string wins { get; set; }
        public Constructor Constructor { get; set; }
    }

    public class StandingsList
    {
        public string season { get; set; }
        public string round { get; set; }
        public List<DriverStanding> DriverStandings { get; set; }
        public List<ConstructorStanding> ConstructorStandings { get; set; }
    }

    public class StandingsTable
    {
        public string season { get; set; }
        public List<StandingsList> StandingsLists { get; set; }
    }

}