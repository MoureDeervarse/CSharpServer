public class ApiResponse
{
    public bool Success { get; set; }
    public int ErrorCode { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}