namespace AOC.Solutions;

public abstract class Day
{
    protected Day(string filePath)
    {
        FilePath = filePath;
    }

    protected string FilePath { get; }
    public abstract void Solve();
}