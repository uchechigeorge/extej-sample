namespace MVCWebApplication1.ViewModels;

public class GetResBodyViewModel<T>
{
  public int Status { get; set; }
  public required string Message { get; set; }
  public IEnumerable<T>? Data { get; set; }
  public int TotalRows { get; set; }
  public int TotalPages { get; set; }
  public int Page { get; set; }
  public string? SortColumn { get; set; }
  public string? SortDirection { get; set; }
  public int PageSize { get; set; }
  public bool HasPreviousPage => Page > 1;
  public bool HasNextPage => Page < TotalPages;
}
