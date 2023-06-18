namespace AOC.Models;

public class Range
{
    public Range(int left, int right)
    {
        Left = left;
        Right = right;
    }
    
    public int Left { get; set; }
    public int Right { get; set; }

    public bool Contains(Range other)
    {
        return Left <= other.Left && Right >= other.Right;
    }

    public bool Overlaps(Range other)
    {
        return (Left >= other.Left && Left <= other.Right)
            || (Right >= other.Left && Right <= other.Right);
    }
}