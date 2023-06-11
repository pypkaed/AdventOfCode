namespace AOC.Models;

public class Scissors : PlayChoice
{
    private IReadOnlyList<string> _winValues;
    private IReadOnlyList<string> _loseValues;

    public Scissors()
    {
        Value = "Scissors";
        Weight = 3;
        _winValues = new List<string>() { "Paper" };
        _loseValues = new List<string>() { "Rock" };
    }

    public override string Value { get; }
    public override int Weight { get; }

    public override IReadOnlyList<string> winValues => _winValues;

    public override IReadOnlyList<string> loseValues => _loseValues;
}