namespace AOC.Models;

public interface IDay
{
    public void Solve();
    public int Year { get; }
    public int Day { get; }
}