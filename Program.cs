using System.Threading.Tasks;

namespace F1Calendar
{
    class Program
    {        
        static async Task Main(string[] args)
        {
            if(args.Length > 0 && (args[0].Equals("calendar")))
            {
                await OutputData.OutputCalendar();
            } else if(args.Length > 0 && (args[0].Equals("drivers")))
            {
                await OutputData.OutputDriverStandings();
            } else if(args.Length > 0 && (args[0].Equals("constructors")))
            {
                await OutputData.OutputConstructorStandings();
            } else
            {
                await OutputData.OutputCalendar();
                await OutputData.OutputDriverStandings();
                await OutputData.OutputConstructorStandings();
            }
        }
    }
}
