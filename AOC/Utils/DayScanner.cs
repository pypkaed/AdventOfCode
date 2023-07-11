using System.Reflection;
using AOC.Models;

namespace AOC.Utils;

public static class DayScanner
{
    public static List<Type> ScanForDayImplementations()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        return assembly.GetTypes().Where(type => typeof(IDay).IsAssignableFrom(type) && type.IsClass).ToList();
    }

    // huuuuuuuuuuhhhhhhhhhhhhh
    public static Dictionary<string, Func<string, IDay>> CreateDayMappingDictionary()
    {
        var daysMapping = new Dictionary<string, Func<string, IDay>>();
        
        foreach (var dayType in ScanForDayImplementations())
        {
            var year = (int)dayType.GetProperty("Year").GetValue(null);
            var day = (int)dayType.GetProperty("Day").GetValue(null);
            string key = StringWorker.GenerateDayKey(year, day);
            
            var constructor = dayType.GetConstructor(new[] { typeof(string) });
            if (constructor != null)
            {
                daysMapping[key] =
                    (filePath) => (IDay)constructor.Invoke(new object[] { filePath });
            }
        }

        return daysMapping;
    }
}