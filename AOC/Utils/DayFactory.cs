using AOC.Models;
using AOC.Utils;

namespace AOC.Solutions;

public class DayFactory
{
    // private static Dictionary<string, Func<string, IDay>> _daysMapping = new()
    // {
    //     { "2022-01" , (filePath) => new DayOneY2022(filePath) },
    //     { "2022-02" , (filePath) => new DayTwoY2022(filePath) },
    //     { "2022-03" , (filePath) => new DayThreeY2022(filePath) },
    //     { "2022-04" , (filePath) => new DayFourY2022(filePath) },
    //     { "2022-05" , (filePath) => new DayFiveY2022(filePath) },
    // };
    private Dictionary<string, Func<string, IDay>> _daysMapping;
    public DayFactory()
    {
        _daysMapping = DayScanner.CreateDayMappingDictionary();
    }

    public IDay GetDay(int year, int day)
    {
        
        return _daysMapping[StringWorker.GenerateDayKey(year, day)](StringWorker.GetPuzzleInputFilePath(year, day));
    }
}