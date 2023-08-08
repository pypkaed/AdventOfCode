using AOC.Solutions;
using AOC.Utils;

namespace AOC;

public class Program
{
    public static async Task Main()
    {
        var communicator = new WebsiteCommunicator();
        var dayFactory = new DayFactory();

        for (var year = 2022; year <= 2022; year++)
        {
            for (var day = 1; day <= dayFactory.GetDaysCount(); day++)
            {
                Console.WriteLine($"--- Day {day} ---");
                
                await communicator.StoreRemoteInput(year, day);
                
                var dayPuzzle = dayFactory.GetDay(year, day);
                dayPuzzle.Solve();
                
                Console.WriteLine();
            }
        }
    }
}