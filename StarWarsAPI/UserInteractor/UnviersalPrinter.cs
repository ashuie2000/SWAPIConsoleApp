
namespace StarWarsAPI.UserInteractor;

public static class UnviersalPrinter
{
    public static void Print<T>(IEnumerable<T> data)
    {
        if (data is null)
        {
            Console.WriteLine("Data is null.");
            return;
        }

        const int columnWidth = 15;

        var properties = typeof(T).GetProperties();

        // Print header
        foreach (var property in properties)
        {
            Console.Write($"{{0,-{columnWidth}}}|", property.Name);
        }
        Console.WriteLine();

        // Print separator line
        Console.WriteLine(new string('-', properties.Length * (columnWidth + 1) ));

        // Print data rows
        foreach (var item in data)
        {
            foreach (var property in properties)
            {
                var value = property.GetValue(item);
                Console.Write($"{{0, -{columnWidth}}}|", value);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', properties.Length * (columnWidth + 1)));
        }

    }
}




