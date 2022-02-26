using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ConsoleTables;
using Pastel;

namespace F1Calendar
{
    public class OutputData
    {
        public static async Task OutputCalendar()
        {
            List<Race> races = await GetData.GetCalendarFromApi();

            Console.WriteLine("2022 F1 CALENDAR".Pastel(Color.Red).PastelBg(Color.Black));
            Console.WriteLine();

            // Clear any existing text from file & add title
            File.WriteAllText("calendar.txt", "2022 F1 CALENDAR \n\n");
            
            // Loop through race list & output details to console
            foreach(Race race in races)
            {
                var raceStartLocal = race.raceStartUtc.ToLocalTime();

                Console.WriteLine($"Round {race.round}".Pastel(Color.Cyan));
                Console.WriteLine(race.raceName);
                Console.WriteLine(race.Circuit.circuitName);
                Console.WriteLine($"{raceStartLocal} your time");
                Console.WriteLine();

                // Also write race calendar to text file
                using(var writer = File.AppendText($"calendar.txt"))
                {
                    writer.WriteLine($"Round {race.round}");
                    writer.WriteLine(race.raceName);
                    writer.WriteLine(race.Circuit.circuitName);
                    writer.WriteLine($"{raceStartLocal} your time");
                    writer.WriteLine();
                }
            }
        }

        public static async Task OutputDriverStandings()
        {
            StandingsList standings = await GetData.GetDriverStandingsFromApi();
            List<DriverStanding> drivers = standings.DriverStandings;

            Console.WriteLine($"{standings.season} DRIVERS CHAMPIONSHIP".Pastel(Color.Yellow).PastelBg(Color.Black));
            Console.WriteLine();

            // Clear any existing text from file & add title
            File.WriteAllText("drivers.txt", $"{standings.season} DRIVERS CHAMPIONSHIP \n\n");

            // Construct standings table
            var table = new ConsoleTable("", "", "Driver", "Team", "Points", "Wins");
            
            // Loop through list of drivers
            foreach(DriverStanding driver in drivers)
            {
                // Add a row to the table containing the driver's details, points etc.
                table.AddRow(driver.position, driver.Driver.code, driver.Driver.familyName, driver.Constructors[0].name, driver.points, driver.wins);
                
                // Also write driver details to text file
                using(var writer = File.AppendText($"drivers.txt"))
                {
                    writer.WriteLine($"{driver.position}. {driver.Driver.code}");
                    writer.WriteLine($"{driver.Driver.givenName} {driver.Driver.familyName}");
                    writer.WriteLine($"{driver.Constructors[0].name}");
                    writer.WriteLine($"{driver.points} points");
                    writer.WriteLine($"{driver.wins} wins");
                    writer.WriteLine();
                }
            }

            // Write table to console
            table.Write(Format.Minimal);
        }

        public static async Task OutputConstructorStandings()
        {
            StandingsList standings = await GetData.GetConstructorStandingsFromApi();
            List<ConstructorStanding> constructors = standings.ConstructorStandings;

            Console.WriteLine($"{standings.season} CONSTRUCTORS CHAMPIONSHIP".Pastel(Color.Cyan).PastelBg(Color.Black));
            Console.WriteLine();

            // Clear any existing text from file & add title
            File.WriteAllText("constructors.txt", $"{standings.season} CONSTRUCTORS CHAMPIONSHIP \n\n");

            // Construct standings table
            var table = new ConsoleTable("", "Team", "Points", "Wins");
            
            // Loop through list of drivers
            foreach(ConstructorStanding constructor in constructors)
            {
                // Add a row to the table containing the team name, points etc.
                table.AddRow(constructor.position, constructor.Constructor.name, constructor.points, constructor.wins);
                
                // Also write team details to text file
                using(var writer = File.AppendText($"constructors.txt"))
                {
                    writer.WriteLine($"{constructor.position}. {constructor.Constructor.name}");
                    writer.WriteLine($"{constructor.points} points");
                    writer.WriteLine($"{constructor.wins} wins");
                    writer.WriteLine();
                }
            }

            // Write table to console
            table.Write(Format.Minimal);
        }
    }
}