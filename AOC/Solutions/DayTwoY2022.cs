using AOC.Models;
using AOC.Attributes;

namespace AOC.Solutions;

[Day(year: 2022, day: 2)]
public class DayTwoY2022 : Day
{
    public DayTwoY2022(string filePath) : base(filePath)
    { }

    // maybe use yield for this?? i don't like doing I/O in logic method

    public override void Solve()
    {
        SolvePartOne();
        SolvePartTwo();
    }

    public void SolvePartOne()
    {
        int totalScore = 0;
        
        using (var streamReader = new StreamReader(FilePath))
        {
            string? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                var choices = line.Split(" ");
                PlayChoice opponentChoice = PlayChoiceFactory.GetInstance(choices[0]);
                PlayChoice myChoice = PlayChoiceFactory.GetInstance(choices[1]);

                switch (myChoice.Play(opponentChoice))
                {
                    case GameOutcome.Lose:
                        totalScore += myChoice.Weight + 0;
                        break;
                    case GameOutcome.Match:
                        totalScore += myChoice.Weight + 3;
                        break;
                    case GameOutcome.Win:
                        totalScore += myChoice.Weight + 6;
                        break;
                }
            }
        }
        
        Console.WriteLine(totalScore);
    }

    public void SolvePartTwo()
    {
        int totalScore = 0;
        
        using (var streamReader = new StreamReader(FilePath))
        {
            string? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                var choices = line.Split(" ");
                PlayChoice opponentChoice = PlayChoiceFactory.GetInstance(choices[0]);
                PlayChoice myChoice;
                
                switch (choices[1])
                {
                    case "X":
                        myChoice = PlayChoiceFactory.GetInstance(opponentChoice.winValues[0]);
                        break;
                    case "Y":
                        myChoice = PlayChoiceFactory.GetInstance(opponentChoice.Value);
                        break;
                    case "Z":
                        myChoice = PlayChoiceFactory.GetInstance(opponentChoice.loseValues[0]);
                        break;
                    default:
                        myChoice = null;
                        break;
                }

                switch (myChoice.Play(opponentChoice))
                {
                    case GameOutcome.Lose:
                        totalScore += myChoice.Weight + 0;
                        break;
                    case GameOutcome.Match:
                        totalScore += myChoice.Weight + 3;
                        break;
                    case GameOutcome.Win:
                        totalScore += myChoice.Weight + 6;
                        break;
                }
            }
        }
        
        Console.WriteLine(totalScore);
    }
}