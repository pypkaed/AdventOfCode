namespace AOC.Utils;

public static class Reader
{
    public static IEnumerable<string> ReadLinesFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }

}