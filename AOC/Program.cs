using AOC.Models;
using AOC.Solutions;

namespace AOC;

public class Program
{
    public static void Main()
    {
        var filePathDayOne = "/home/pypka/RiderProjects/AdventOfCode/AOC/Input/DayOneInput.txt";
        var filePathDayTwo = "/home/pypka/RiderProjects/AdventOfCode/AOC/Input/DayTwoInput.txt";
        
        IDay day = new DayOne(filePathDayOne);
        day.Solve();
        Console.WriteLine();
        
        day = new DayTwo(filePathDayTwo);
        day.Solve();
    }
}