using AOC.Attributes;
using AOC.Utils;

namespace AOC.Solutions;

[Day(year: 2022, day: 6)]
public class DaySixY2022 : Day
{
    public DaySixY2022(string filePath) : base(filePath)
    { }

    public override void Solve()
    {
        SolvePartOne();
        SolvePartTwo();
    }

    private void SolvePartOne()
    {
        var input = Reader.ReadLinesFromFile(FilePath);

        var window = new Window(startIndex: 0, endIndex: 3);
        var hashMap = new Dictionary<char, int>();

        // i dont like this >:(
        foreach (var line in input)
        {
            int i = window.StartIndex;
            while (i <= window.EndIndex)
            {
                if (hashMap.ContainsKey(line[i]))
                {
                    window.MoveEdges();
                    hashMap.Clear();
                    i = window.StartIndex - 1;
                }
                else
                {
                    hashMap[line[i]] = i;
                }

                i++;
            }
            
            Console.WriteLine(i);
        }
    }

    private void SolvePartTwo()
    {
        var input = Reader.ReadLinesFromFile(FilePath);

        var window = new Window(startIndex: 0, endIndex: 13);
        var hashMap = new Dictionary<char, int>();

        // i dont like this >:(
        foreach (var line in input)
        {
            int i = window.StartIndex;
            while (i <= window.EndIndex)
            {
                if (hashMap.ContainsKey(line[i]))
                {
                    window.MoveEdges();
                    hashMap.Clear();
                    i = window.StartIndex - 1;
                }
                else
                {
                    hashMap[line[i]] = i;
                }

                i++;
            }
            
            Console.WriteLine(i);
        }
    }
}

internal struct Window
{
    public Window(int startIndex, int endIndex)
    {
        StartIndex = startIndex;
        EndIndex = endIndex;
    }
    public int StartIndex { get; private set; }
    public int EndIndex { get; private set; }

    public void MoveEdges(int times = 1)
    {
        StartIndex += times;
        EndIndex += times;
    }
}