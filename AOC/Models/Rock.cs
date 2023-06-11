namespace AOC.Models;

public class Rock : PlayChoice
{
    private IReadOnlyList<string> _winValues;
    private IReadOnlyList<string> _loseValues;

    public Rock()
    {
        Value = "Rock";
        Weight = 1;
        _winValues = new List<string>() { "Scissors" };
        _loseValues = new List<string>() { "Paper" };
    }

    public override string Value { get; }
    public override int Weight { get; }

    public override IReadOnlyList<string> winValues => _winValues;

    public override IReadOnlyList<string> loseValues => _loseValues;
}