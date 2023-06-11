namespace AOC.Models;

public class PlayChoiceFactory
{
    private static readonly Dictionary<string, Func<PlayChoice>> _choiceMappingPartOne
        = new()
        {
            { "A", () => new Rock() },
            { "X", () => new Rock() },
            { "Rock", () => new Rock() },
            { "B", () => new Paper() },
            { "Y", () => new Paper() },
            { "Paper", () => new Paper() },
            { "C", () => new Scissors() },
            { "Z", () => new Scissors() },
            { "Scissors", () => new Scissors() },
        };

    public static PlayChoice GetInstance(string value)
    {
        return _choiceMappingPartOne[value]();
    }
}