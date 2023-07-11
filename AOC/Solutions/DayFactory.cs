using AOC.Models;

namespace AOC.Solutions;

public static class DayFactory
{
    private static Dictionary<string, Func<string, IDay>> _daysMapping = new()
    {
        { "2022-01" , (filePath) => new DayOneY2022(filePath) },
        { "2022-02" , (filePath) => new DayTwoY2022(filePath) },
        { "2022-03" , (filePath) => new DayThreeY2022(filePath) },
        { "2022-04" , (filePath) => new DayFourY2022(filePath) },
        { "2022-05" , (filePath) => new DayFiveY2022(filePath) },
    };

    private static string GetPuzzleInputFilePath(int year, int day)
    {
        return $"../../../Input/{year}_day_{day}_input.txt";
    }

    public static IDay GetDay(int year, int day)
    {
        return _daysMapping[$"{year}-{(day < 10 ? "0" + day : day)}"](GetPuzzleInputFilePath(year, day));
    }
}