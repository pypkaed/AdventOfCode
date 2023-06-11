namespace AOC.Models;

public abstract class PlayChoice
{
    public abstract string Value { get; }
    public abstract int Weight { get; }
    public abstract IReadOnlyList<string> winValues { get; }
    public abstract IReadOnlyList<string> loseValues { get; }

    public GameOutcome Play(PlayChoice otherChoice)
    {
        if (Value == otherChoice.Value)
        {
            return GameOutcome.Match;
        }

        if (winValues.Contains(otherChoice.Value))
        {
            return GameOutcome.Win;
        }
        if (loseValues.Contains(otherChoice.Value))
        {
            return GameOutcome.Lose;
        }

        throw new Exception("Invalid letter");
    }
}