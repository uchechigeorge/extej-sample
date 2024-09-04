namespace MVCWebApplication1.Data;

public class ViewQuery<T>
{
    /// <summary>
    /// The query of the related entity
    /// </summary>
    public required IQueryable<T> Query { get; set; }

    /// <summary>
    /// The data for the related entity
    /// </summary>
    public required IEnumerable<T> Data { get; set; }
    /// <summary>
    /// Number of rows returned
    /// </summary>
    public int TotalRows { get; set; }
    public string? SortColumn { get; set; }
    public bool IsDescending { get; set; }
    public string? SortDirection { get => IsDescending ? "desc" : "asc"; }
    /// <summary>
    /// Extra details for the related entity
    /// </summary>
    public Dictionary<string, object>? Extras { get; set; }
}
