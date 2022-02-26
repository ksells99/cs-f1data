using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;


namespace F1Calendar
{
    public class GetData
    {
        public static HttpClient client = new HttpClient();
        
        // Returns a task whose result is a list of Race objects
        public static async Task<List<Race>> GetCalendarFromApi()
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

        public static async Task<StandingsList> GetDriverStandingsFromApi()
        {
            // Set up HTTP headers
            client.DefaultRequestHeaders.Accept.Clear();
            // Accept json responses
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );

            // Fetch data from Ergast API
            var streamTask = client.GetStreamAsync("http://ergast.com/api/f1/current/driverStandings.json");

            // Deserialise json response & return standingslist (includes season plus DriverStandings list)
            var response = await JsonSerializer.DeserializeAsync<Root>(await streamTask);
            return response.MRData.StandingsTable.StandingsLists[0];
        }

        public static async Task<StandingsList> GetConstructorStandingsFromApi()
        {
            // Set up HTTP headers
            client.DefaultRequestHeaders.Accept.Clear();
            // Accept json responses
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );

            // Fetch data from Ergast API
            var streamTask = client.GetStreamAsync("http://ergast.com/api/f1/current/constructorStandings.json");

            // Deserialise json response & return standingslist (includes season plus ConstructorStandings list)
            var response = await JsonSerializer.DeserializeAsync<Root>(await streamTask);
            return response.MRData.StandingsTable.StandingsLists[0];
        }
    }
}