using AOC.Models;
using AOC.Solutions;

namespace AOC;

public class Program
{
    public static void Main()
    {
        // TODO: automate downloading, paths to files via HTTP requests.
        var filePathDayOne = "/home/pypka/RiderProjects/AdventOfCode/AOC/Input/DayOneInput.txt";
        var filePathDayTwo = "/home/pypka/RiderProjects/AdventOfCode/AOC/Input/DayTwoInput.txt";
        var filePathDayThree = "/home/pypka/RiderProjects/AdventOfCode/AOC/Input/DayThreeInput.txt";
        var filePathDayFour = "/home/pypka/RiderProjects/AdventOfCode/AOC/Input/DayFourInput.txt";
        var filePathDayFive = "/home/pypka/RiderProjects/AdventOfCode/AOC/Input/DayFiveInput.txt";
        
        Console.WriteLine("--- Day one ---");
        IDay day = new DayOne(filePathDayOne);
        day.Solve();
        Console.WriteLine();
        
        Console.WriteLine("--- Day two ---");
        day = new DayTwo(filePathDayTwo);
        day.Solve();
        Console.WriteLine();
        
        Console.WriteLine("--- Day three ---");
        day = new DayThree(filePathDayThree);
        day.Solve();
        Console.WriteLine();
        
        Console.WriteLine("--- Day four ---");
        day = new DayFour(filePathDayFour);
        day.Solve();
        Console.WriteLine();
        
        Console.WriteLine("--- Day five ---");
        day = new DayFive(filePathDayFive);
        day.Solve();
        Console.WriteLine();
    }
}