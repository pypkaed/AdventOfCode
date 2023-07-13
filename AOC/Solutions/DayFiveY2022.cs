using AOC.Attributes;
using AOC.Utils;

namespace AOC.Solutions;

[Day(year: 2022, day: 5)]
public class DayFiveY2022 : Day
{
    public DayFiveY2022(string filePath) : base(filePath)
    { }

    public override void Solve()
    {
        SolvePartOne();
        Console.WriteLine();
        SolvePartTwo();
    }

    public void SolvePartOne()
    {
        var fileInput = Reader.ReadLinesFromFile(FilePath);
        var stacks = DayFiveParser.ParseStacks(fileInput, 0, 7);

        for (int i = 10; i < fileInput.Count(); i++)
        {
            DayFiveParser.ParseCommand(
                fileInput.ElementAt(i),
                out var moveCount,
                out var moveFrom,
                out var moveTo);

            for (int j = 0; j < moveCount; j++)
            {
                var element = stacks.ElementAt(moveFrom - 1).Pop();
                stacks.ElementAt(moveTo - 1).Push(element);
            }
        }

        foreach (var stack in stacks)
        {
            Console.Write(stack.Peek());
        }
    }

    public void SolvePartTwo()
    {
        var fileInput = Reader.ReadLinesFromFile(FilePath);
        var stacks = DayFiveParser.ParseStacks(fileInput, 0, 7);

        for (int i = 10; i < fileInput.Count(); i++)
        {
            DayFiveParser.ParseCommand(
                                       fileInput.ElementAt(i),
                                       out var moveCount,
                                       out var moveFrom,
                                       out var moveTo);
            var movingCrates = new Stack<char>();
            for (int j = 0; j < moveCount; j++)
            {
                movingCrates.Push(stacks.ElementAt(moveFrom - 1).Pop());
            }
            for (int j = 0; j < moveCount; j++)
            {
                stacks.ElementAt(moveTo - 1).Push(movingCrates.Pop());
            }
        }

        foreach (var stack in stacks)
        {
            Console.Write(stack.Peek());
        }
    }
}