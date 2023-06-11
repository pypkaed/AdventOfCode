namespace AOC.Models;

public class Paper : PlayChoice
{
    private IReadOnlyList<string> _winValues;
    private IReadOnlyList<string> _loseValues;

    public Paper()
    {
        Value = "Paper";
        Weight = 2;
        _winValues = new List<string>() { "Rock" };
        _loseValues = new List<string>() { "Scissors" };
    }

    public override string Value { get; }
    public override int Weight { get; }

    public override IReadOnlyList<string> winValues => _winValues;

    public override IReadOnlyList<string> loseValues => _loseValues;
}