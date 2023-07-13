using AOC.Models;
using AOC.Utils;

namespace AOC.Solutions;

public class DayFactory
{
    private Dictionary<string, Func<string, Day>> _daysMapping;
    public DayFactory()
    {
        _daysMapping = DayScannerAutomation.CreateDayMappingDictionary();
    }

    public int GetDaysCount() => _daysMapping.Count;

    public Day GetDay(int year, int day)
    {
        
        return _daysMapping[StringWorker.GenerateDayKey(year, day)](StringWorker.GetPuzzleInputFilePath(year, day));
    }
}