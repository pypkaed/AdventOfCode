namespace AOC.Models;

public interface IDay
{
    void Solve();
    static int Year { get; }
    static int Day { get; }
}