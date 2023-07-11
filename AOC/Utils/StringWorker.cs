namespace AOC.Utils;

public static class StringWorker
{
    public static string GetPuzzleInputFilePath(int year, int day)
    {
        return $"../../../Input/{year}_day_{day}_input.txt";
    }
    
    public static string GenerateDayKey(int year, int day)
    {
        return $"{year}-{(day < 10 ? "0" + day : day)}";
    }
}