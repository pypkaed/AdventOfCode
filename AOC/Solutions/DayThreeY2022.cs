using AOC.Utils;
using AOC.Attributes;

namespace AOC.Solutions;

[Day(year: 2022, day: 3)]
public class DayThreeY2022 : Day
{
    private Dictionary<char, int> _costs;
    private const int TeamSize = 3;

    public DayThreeY2022(string filePath) : base(filePath)
    { }

    public static int Year => 2022;

    public static int Day => 3;

    private void InitializeCosts()
    {
        _costs.Clear();
        
        int value = 1;
        for (char c = 'a'; c <= 'z'; c++)
        {
            _costs.Add(c, value++);
        }
        for (char c = 'A'; c <= 'Z'; c++)
        {
            _costs.Add(c, value++);
        }
    }

    public override void Solve()
    {
        SolvePartOne();
        SolvePartTwo();
    }

    public void SolvePartOne()
    {
        _costs = new Dictionary<char, int>();

        InitializeCosts();
        int totalSum = 0;
        
        var fileInput = Reader.ReadLinesFromFile(FilePath);

        foreach (var line in fileInput)
        {
            totalSum += _costs[FindFirstDuplicate(line)];
        }
        
        Console.WriteLine(totalSum);
    }

    private char FindFirstDuplicate(string line)
    {
        var itemsFirstHalf = new HashSet<char>();
        for (int i = 0; i < line.Length / 2; i++)
        {
            itemsFirstHalf.Add(line[i]);
        }
        for (int i = line.Length / 2; i < line.Length; i++)
        {
            if (itemsFirstHalf.Contains(line[i]))
            {
                return line[i];
            }
        }

        throw new Exception("No duplicates");
    }

    public void SolvePartTwo()
    {
        _costs = new Dictionary<char, int>();

        InitializeCosts();
        
        int totalSum = 0;
        var fileInput = Reader.ReadLinesFromFile(FilePath);
        var batchOfLines = new List<string>();

        foreach (var line in fileInput)
        {
            batchOfLines.Add(line);

            if (batchOfLines.Count % TeamSize == 0)
            {
                totalSum += _costs[FindFirstDuplicate(batchOfLines)];
                
                batchOfLines.Clear();
            }
        }
        
        Console.WriteLine(totalSum);
    }

    public char FindFirstDuplicate(IEnumerable<string> lines)
    {
        var linesList = lines.ToList();
        var result = new HashSet<char>(linesList[0]);
        
        foreach (var line in linesList)
        {
            var items = new HashSet<char>(line);
            foreach (var c in result)
            {
                if (!items.Contains(c))
                {
                    result.Remove(c);
                }
            }
        }

        return result.First();
    }
}