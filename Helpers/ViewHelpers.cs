namespace MVCWebApplication1.Helpers;

public class ViewHelpers
{
  /// <summary>
  /// Gets a valid sort column from list of column options, otherwise the default value
  /// </summary>
  /// <param name="column"></param>
  /// <param name="options">Column options</param>
  /// <param name="defaultColumn">The default sort column</param>
  /// <returns></returns>
  public static string GetSortColumn(string? column, Dictionary<string, string> options, string defaultColumn = "DateModified")
  {
    if (string.IsNullOrWhiteSpace(column)) return defaultColumn;

    //bool containsKey = options.TryGetValue(value, out string selected);

    var selected = options.FirstOrDefault(option => option.Key.ToLower() == column.ToLower());
    var contains = options.Any(option => option.Key.ToLower() == column.ToLower());

    return contains ? (string.IsNullOrWhiteSpace(selected.Value) ? selected.Key : selected.Value) : defaultColumn;
  }

  /// <summary>
  /// Returns true for descending order and vice versa
  /// </summary>
  /// <param name="value"></param>
  /// <returns></returns>
  public static bool IsDescendingOrder(string? value)
  {
    return value != null && (value.Equals("desc", StringComparison.CurrentCultureIgnoreCase) || value.IsTruthy());
  }
}