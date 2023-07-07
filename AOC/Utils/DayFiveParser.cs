using System.Text.RegularExpressions;

namespace AOC.Utils;

public static class DayFiveParser
{
    private static readonly Regex BoxPattern = new Regex(@"\[\S\]", RegexOptions.Compiled);
    private static readonly Regex MoveCommandPattern = new Regex(@"move \d+", RegexOptions.Compiled);
    private static readonly Regex FromCommandPattern = new Regex(@"from \d+", RegexOptions.Compiled);
    private static readonly Regex ToCommandPattern = new Regex(@"to \d+", RegexOptions.Compiled);

    private const int StackLineLength = 4;

    public static List<Stack<char>> ParseStacks(
        IEnumerable<string> fileInput,
        int firstStackLine,
        int lastStackLine)
    {
        if (firstStackLine > lastStackLine) throw new Exception("First stack line should be less than las stack line.");

        // initialize N stacks in list:
        var numOfStacks = (fileInput.ElementAt(0).Length / 4) + 1;
        var resultStacks = Enumerable.Range(0, numOfStacks)
                                     .Select(_ => new Stack<char>())
                                     .ToList();
        
        for (var i = lastStackLine; i >= firstStackLine; i--)
        {
            var line = fileInput.ElementAt(i);
            foreach (var match in BoxPattern.Matches(line).Cast<Match>())
            {
                int stackNum = match.Index / StackLineLength;
                char actualValue = match.Value[1];
                
                resultStacks[stackNum].Push(actualValue);
            }
        }

        return resultStacks;
    }

    public static void ParseCommand(
        string command,
        out int moveCount,
        out int moveFrom,
        out int moveTo)
    {
        moveCount = moveFrom = moveTo = 0;
        
        moveCount += MoveCommandPattern.Matches(command)
                                       .Sum(match =>
                                                Int32.Parse(match.Value.Split(" ")[1]));

        moveFrom = FromCommandPattern.Matches(command)
                                     .Select(match 
                                                 => Int32.Parse(match.Value.Split(" ")[1]))
                                     .FirstOrDefault();
        
        moveTo = ToCommandPattern.Matches(command)
                                 .Select(match 
                                             => Int32.Parse(match.Value.Split(" ")[1]))
                                 .FirstOrDefault();
    }
}