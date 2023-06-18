using AOC.Models;
using AOC.Utils;
using Range = AOC.Models.Range;

namespace AOC.Solutions;

public class DayFour : IDay
{
    private readonly string _filePath;
    public DayFour(string filePath)
    {
        _filePath = filePath;
    }
    
    public void Solve()
    {
        SolvePartOne();
        SolvePartTwo();
    }

    public void SolvePartOne()
    {
        int totalCount = 0;
        var fileInput = Reader.ReadLinesFromFile(_filePath);
        
        foreach (var line in fileInput)
        {
            GetRanges(line, out var firstRange, out var secondRange);

            if (firstRange.Contains(secondRange) || secondRange.Contains(firstRange))
            {
                totalCount++;
            }
        }
        
        Console.WriteLine(totalCount);
    }

    private string[] SeparateInput(string line, string separator)
    {
        return line.Split(separator);
    }

    private void GetRanges(string line, out Range firstRange, out Range secondRange)
    {
        var pairs = SeparateInput(line, ",");
        var firstRanges = SeparateInput(pairs[0], "-");
        var secondRanges = SeparateInput(pairs[1], "-");

        firstRange = new Range(Int32.Parse(firstRanges[0]), Int32.Parse(firstRanges[1]));
        secondRange = new Range(Int32.Parse(secondRanges[0]), Int32.Parse(secondRanges[1]));
    }

    public void SolvePartTwo()
    {
        int totalCount = 0;
        var fileInput = Reader.ReadLinesFromFile(_filePath);
        
        foreach (var line in fileInput)
        {
            GetRanges(line, out var firstRange, out var secondRange);

            if (firstRange.Overlaps(secondRange) || secondRange.Overlaps(firstRange))
            {
                totalCount++;
            }
        }
        
        Console.WriteLine(totalCount);
    }
}