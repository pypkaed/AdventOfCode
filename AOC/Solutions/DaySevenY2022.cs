using AOC.Attributes;
using AOC.Models;
using AOC.Utils;

namespace AOC.Solutions;

[Day(2022, 7)]
public class DaySevenY2022 : Day
{
    public DaySevenY2022(string filePath) : base(filePath)
    { }

    public override void Solve()
    {
        SolvePartOne();
        SolvePartTwo();
    }

    private void SolvePartOne()
    {
        var fs = InitializeTree();
        fs.CalculateDirSizes();

        var res = 0L;
        
        res = CalculateSumOfSizes(fs.Root);
        
        Console.WriteLine(res);
    }
    
    private long CalculateSumOfSizes(DirectoryDaySeven directory)
    {
        long sum = 0;

        if (directory.Size <= 100000)
        {
            sum += directory.Size;
        }

        foreach (var child in directory.Children)
        {
            if (child is DirectoryDaySeven childDirectory)
            {
                sum += CalculateSumOfSizes(childDirectory);
            }
        }

        return sum;
    }

    private TreeDaySeven InitializeTree()
    {
        var input = Reader.ReadLinesFromFile(FilePath);
        var inputList = input.ToList();
        
        string rootName = inputList[0].Split(' ')[2];
        var root = new DirectoryDaySeven(rootName, null);
        var fs = new TreeDaySeven(root);

        var currentDir = root;

        for (int i = 1; i < inputList.Count; i++)
        {
            var line = inputList[i].Split(' ');
            if (line[0] == "$")
            {
                if (line[1] == "cd")
                {
                    if (line[2] == "..")
                    {
                        currentDir = currentDir?.Parent;
                    }
                    else
                    {
                        currentDir = currentDir.Children
                                               .OfType<DirectoryDaySeven>()
                                               .FirstOrDefault(d => 
                                                                   d.Equals(new DirectoryDaySeven(currentDir.Name + "/" + line[2], currentDir)));
                    }
                }
            }
            else
            {
                if (line[0] == "dir")
                {
                    currentDir.AddChild(new DirectoryDaySeven( currentDir.Name+ "/" + line[1], currentDir));
                }
                else
                {
                    currentDir.AddChild(
                                        new FileDaySeven(
                                                         Int32.Parse(line[0]),
                                                         currentDir.Name + "/" + line[1]));
                }
            }
        }

        return fs;
    }
    
    private void SolvePartTwo()
    { }
}