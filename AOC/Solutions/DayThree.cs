using AOC.Models;

namespace AOC.Solutions;

public class DayThree : IDay
{
    private string _filePath;
    private Dictionary<char, int> costs;
    private const int TeamSize = 3;

    public DayThree(string filePath)
    {
        _filePath = filePath;
        costs = new Dictionary<char, int>();

        InitializeCosts();
    }

    private void InitializeCosts()
    {
        costs.Clear();
        
        int value = 1;
        for (char c = 'a'; c <= 'z'; c++)
        {
            costs.Add(c, value++);
        }
        for (char c = 'A'; c <= 'Z'; c++)
        {
            costs.Add(c, value++);
        }
    }

    private static IEnumerable<string> ReadLinesFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }

    public void Solve()
    {
        SolvePartOne();
        SolvePartTwo();
    }

    public void SolvePartOne()
    {
        int totalSum = 0;
        
        var fileInput = ReadLinesFromFile(_filePath);

        foreach (var line in fileInput)
        {
            totalSum += costs[FindFirstDuplicate(line)];
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
        int totalSum = 0;
        var fileInput = ReadLinesFromFile(_filePath);
        var batchOfLines = new List<string>();

        foreach (var line in fileInput)
        {
            batchOfLines.Add(line);

            if (batchOfLines.Count % TeamSize == 0)
            {
                totalSum += costs[FindFirstDuplicate(batchOfLines)];
                
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