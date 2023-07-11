using AOC.Models;
using AOC.Solutions;
using AOC.Utils;

namespace AOC;

public class Program
{
    public static async Task Main()
    {
        var communicator = new WebsiteCommunicator();

        for (var year = 2022; year <= 2022; year++)
        {
            for (var day = 1; day <= 5; day++)
            {
                Console.WriteLine($"--- Day {day} ---");
                
                await communicator.StoreRemoteInput(year, day);
                
                var dayPuzzle = DayFactory.GetDay(year, day);
                dayPuzzle.Solve();
                
                Console.WriteLine();
            }

        }
    }
}