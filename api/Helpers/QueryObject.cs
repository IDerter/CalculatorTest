namespace api.Helpers;

public class QueryObject
{
    public string? Type { get; set; } = string.Empty;
    public string? SortBy { get; set; } = string.Empty;
    public bool IsDescending { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
