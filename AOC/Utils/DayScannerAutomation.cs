using System.Reflection;
using AOC.Attributes;
using AOC.Solutions;

namespace AOC.Utils;

public static class DayScannerAutomation
{
    // example of entry to the dictionary:
    // { "2022-01", (filePath) => new DayOne(filePath) }
    public static Dictionary<string, Func<string, Day>> CreateDayMappingDictionary()
    {
        var daysMapping = new Dictionary<string, Func<string, Day>>();
        
        foreach (var dayType in ScanForDayAnnotatedClasses())
        {
            var attribute = dayType.GetCustomAttribute<DayAttribute>();
            
            string key = StringWorker.GenerateDayKey(attribute!.Year, attribute!.Day);
            
            var constructor = GetConstructor(dayType,
                                             ctorArguments: new[] { typeof(string) });
            if (constructor != null)
            {
                daysMapping[key] =
                    (filePath) => (Day)constructor.Invoke(new object[] { filePath });
            }
        }
    
        return daysMapping;
    }

    private static List<Type> ScanForDayAnnotatedClasses()
    {
        return Assembly.GetExecutingAssembly()
                       .GetTypes()
                       .Where(type =>
                                  type.GetCustomAttribute<DayAttribute>() != null)
                       .ToList();
    }

    private static ConstructorInfo? GetConstructor(Type dayType, Type[] ctorArguments)
    {
        return dayType.GetConstructor(ctorArguments);
    }
}