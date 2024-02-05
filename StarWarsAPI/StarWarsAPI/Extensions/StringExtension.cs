namespace StarWarsAPI.Extensions;

public static class StringExtension
{
    public static int? IntOrNull(this string? data)
    {
        return int.TryParse(data, out int number) ? number : null;
    }

    public static long? LongOrNull(this string? data)
    {
        return long.TryParse(data, out long number) ? number : null;
    }
}