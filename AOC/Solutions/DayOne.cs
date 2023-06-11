using AOC.Models;

namespace AOC.Solutions;

public class DayOne : IDay
{
    private string _filePath;

    public DayOne(string filePath)
    {
        _filePath = filePath;
    }

    public void Solve()
    {
        Console.WriteLine(SolvePartOne());
        Console.WriteLine(SolvePartTwo());
    }

    public int SolvePartOne()
    {
        var elves = InitializeElfCalories(_filePath);

        return FindElfWithMaxCalories(elves).Calories;
    }

    public int SolvePartTwo()
    {
        var elves = InitializeElfCalories(_filePath);
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