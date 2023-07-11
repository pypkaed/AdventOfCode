using System.Reflection;
using AOC.Models;

namespace AOC.Utils;

public static class DayScannerAutomation
{
    public static List<Type> ScanForDayImplementations()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        return assembly.GetTypes().Where(type => typeof(IDay).IsAssignableFrom(type) && type.IsClass).ToList();
    }

    // example of entry to the dictionary:
    // { "2022-01", (filePath) => new DayOne(filePath) }
    public static Dictionary<string, Func<string, IDay>> CreateDayMappingDictionary()
    {
        var daysMapping = new Dictionary<string, Func<string, IDay>>();
        
        foreach (var dayType in ScanForDayImplementations())
        {
            var year = (int) GetStaticField(dayType, fieldName: "Year");
            var day = (int) GetStaticField(dayType, fieldName: "Day");
            string key = StringWorker.GenerateDayKey(year, day);
            
            var constructor = GetConstructor(dayType, ctorArguments: new[] { typeof(string) });
            if (constructor != null)
            {
                daysMapping[key] =
                    (filePath) => (IDay)constructor.Invoke(new object[] { filePath });
            }
        }

        return daysMapping;
    }

    private static object GetStaticField(Type dayType, string fieldName)
    {
        return (dayType.GetProperty(fieldName)?.GetValue(null) ?? throw new InvalidOperationException());
    }

    private static ConstructorInfo? GetConstructor(Type dayType, Type[] ctorArguments)
    {
        return dayType.GetConstructor(ctorArguments);
    }
}