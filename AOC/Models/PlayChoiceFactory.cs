namespace AOC.Models;

public class PlayChoiceFactory
{
    private static readonly Dictionary<string, Func<PlayChoice>> _choiceMapping
        = new()
        {
            { "A", () => new Rock() },
            { "X", () => new Rock() },
            { "B", () => new Paper() },
            { "Y", () => new Paper() },
            { "C", () => new Scissors() },
            { "Z", () => new Scissors() },
        };

    public static PlayChoice GetInstance(string letter)
    {
        return _choiceMapping[letter]();
    }
}