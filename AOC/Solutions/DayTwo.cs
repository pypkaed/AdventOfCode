using AOC.Models;

namespace AOC.Solutions;

public class DayTwo : IDay
{
    private readonly string _filePath;
    
    public DayTwo(string filePath)
    {
        _filePath = filePath;
    }

    // maybe use yield for this?? i don't like doing I/O in logic method
    public void Solve()
    {
        int totalScore = 0;
        
        using (var streamReader = new StreamReader(_filePath))
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
}