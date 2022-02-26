using System;
using System.Collections.Generic;

namespace F1Calendar
{

    public class Location
    {
        public string lat { get; set; }
        public string @long { get; set; }
        public string locality { get; set; }
        public string country { get; set; }
    }

    public class Circuit
    {
        public string circuitId { get; set; }
        public string url { get; set; }
        public string circuitName { get; set; }
        public Location Location { get; set; }
    }

    public class Race
    {
        public string season { get; set; }
        public string round { get; set; }
        public string url { get; set; }
        public string raceName { get; set; }
        public Circuit Circuit { get; set; }
        public string date { get; set; }
        public string time { get; set; }

        public DateTime raceStartUtc => DateTime.Parse($"{date} {time}");
    
    }

    public class RaceTable
    {
        public string season { get; set; }
        public List<Race> Races { get; set; }
    }

   

}