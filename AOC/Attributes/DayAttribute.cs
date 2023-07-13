namespace AOC.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class DayAttribute : Attribute
{
    public DayAttribute(int year, int day)
    {
        Year = year;
        Day = day;
    }
    public int Year { get; }
    public int Day { get; }
}