namespace MVCWebApplication1.ViewModels;

public class GetReqParametersViewModel
{
  public int Page { get; set; } = 1;
  public int PageSize { get; set; } = 5;
  public string? SortColumn { get; set; }
  public string? SortDirection { get; set; }
}