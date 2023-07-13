using AOC.Models;
using AOC.Attributes;

namespace AOC.Solutions;

[Day(year: 2022, day: 1)]
public class DayOneY2022 : Day
{
    public DayOneY2022(string filePath) : base(filePath)
    { }

    public override void Solve()
    {
        Console.WriteLine(SolvePartOne());
        Console.WriteLine(SolvePartTwo());
    }

    public int SolvePartOne()
    {
        var elves = InitializeElfCalories(FilePath);

        return FindElfWithMaxCalories(elves).Calories;
    }

    public int SolvePartTwo()
    {
        var elves = InitializeElfCalories(FilePath);
        return elves.OrderByDescending(elf => elf.Calories).Take(3).Sum(elf => elf.Calories);
        
    }

    private List<Elf> InitializeElfCalories(string filePath)
    {
        var elves = new List<Elf>();
        
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            // idk how to do it better for now :(
            var currentElf = new Elf();
            elves.Add(currentElf);

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    currentElf = new Elf();
                    elves.Add(currentElf);
                }
                else
                {
                    currentElf.AddCalories(int.Parse(line));
                }
            }
        }

        return elves;
    }

    private Elf FindElfWithMaxCalories(List<Elf> elves)
    {
        Elf richestElf = new Elf();
        
        foreach (var elf in elves)
        {
            richestElf = (elf.Calories > richestElf.Calories) ? elf : richestElf;
        }

        return richestElf;
    }
}