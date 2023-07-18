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
        FindFirstNDifferentLetters(4);
    }

    private void SolvePartTwo()
    {
        FindFirstNDifferentLetters(14);
    }
    
    private void FindFirstNDifferentLetters(int N)
    {
        var input = Reader.ReadLinesFromFile(FilePath);
        
        var window = new Window(startIndex: 0, endIndex: N - 1);
        var hashMap = new Dictionary<char, int>();

        foreach (var line in input)
        {
            for (int i = window.StartIndex; i <= window.EndIndex; i++)
            {
                if (hashMap.ContainsKey(line[i]))
                {
                    window.MoveEdges();
                    i = window.StartIndex - 1;
                    
                    hashMap.Clear();
                }
                else
                {
                    hashMap[line[i]] = i;
                }
            }
            
            Console.WriteLine(window.EndIndex + 1);
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