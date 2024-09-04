namespace MVCWebApplication1.Helpers;

public static class TypeHelperExtensions
{
    /// <summary>
    /// Returns a valid boolean from string
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool GetBoolean(this string? value)
    {
        return bool.TryParse(value, out bool _) && bool.Parse(value);
    }

    /// <summary>
    /// Checks for valid decimal from an object value and return it otherwise a default value
    /// </summary>
    /// <param name="source"></param>
    /// <param name="defaultValue">The default value</param>
    /// <returns></returns>
    public static decimal GetDecimal(this object? source, decimal defaultValue = 0)
    {
        if (source == null) return defaultValue;
        string? sourceStr = source.ToString();

        return decimal.TryParse(sourceStr, out decimal _) ? decimal.Parse(sourceStr) : defaultValue;
    }

    /// <summary>
    /// Returns a natural number from an integer value
    /// </summary>
    /// <param name="source"></param>
    /// <param name="defaultValue"></param>
    /// <param name="absoluteValue">If set to true, returns absolute value for negative numbers</param>
    /// <returns></return>
    public static int GetNaturalInt(this int source, int defaultValue = 1, bool absoluteValue = false)
    {
        if (absoluteValue)
        {
            source = Math.Abs(source);
        }

        return source < 1 ? defaultValue : source;
    }

    /// <summary>
    /// Returns a natural number from an integer value
    /// </summary>
    /// <param name="source"></param>
    /// <param name="defaultValue"></param>
    /// <param name="absoluteValue">If set to true, returns absolute value for negative numbers</param>
    /// <returns></return>
    public static int GetNaturalInt(this int? source, int defaultValue = 1, bool absoluteValue = false)
    {
        int value = source ?? 0;

        if (absoluteValue)
        {
            value = Math.Abs(value);
        }

        return value < 1 ? defaultValue : value;
    }

    /// <summary>
    /// Checks if a string/object has a truthy value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsTruthy(this object value)
    {
        return value != null
        && (value == (object)true
          || (string)value == 1.ToString()
          || ((string)value)?.ToLower() == bool.TrueString.ToLower());
    }

}