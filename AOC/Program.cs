using AOC.Solutions;

namespace AOC;

public class Program
{
    public static void Main()
    {
        var filePathDayOne = "/home/pypka/RiderProjects/AdventOfCode/AOC/Input/DayOneInput.txt";
        
        var dayOne = new DayOne(filePathDayOne);
        Console.WriteLine(dayOne.SolvePartOne());
        Console.WriteLine(dayOne.SolvePartTwo());
    }
}