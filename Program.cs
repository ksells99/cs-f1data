using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Pastel;

namespace F1Calendar
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        // Returns a task whose result is a list of Race objects
        private static async Task<List<Race>> GetCalendar()
        {
            // Set up HTTP headers
            client.DefaultRequestHeaders.Accept.Clear();
            // Accept json responses
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );

            // Fetch data from Ergast API
            var streamTask = client.GetStreamAsync("http://ergast.com/api/f1/2022.json");

            // Deserialise json response & return nested Races list
            var response = await JsonSerializer.DeserializeAsync<Root>(await streamTask);
            return response.MRData.RaceTable.Races;
        }
        
        
        static async Task Main(string[] args)
        {
            List<Race> races = await GetCalendar();

            Console.WriteLine("2022 F1 CALENDAR".Pastel(Color.Red).PastelBg(Color.Black));
            Console.WriteLine();

            // Clear any existing text from file & add title
            File.WriteAllText("calendar.txt", "2022 F1 CALENDAR \n\n");
            
            // Loop through race list & output details to console
            foreach(var race in races)
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
    }
}
